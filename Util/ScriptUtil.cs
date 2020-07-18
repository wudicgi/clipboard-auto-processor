using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClipboardAutoProcessor.DataStructure;
using MadMilkman.Ini;

namespace ClipboardAutoProcessor.Util
{
    public static class ScriptUtil
    {
        public static BindingList<ScriptFileItem> GetScriptFileList(string path)
        {
            BindingList<ScriptFileItem> scriptFileList = new BindingList<ScriptFileItem>();

            {
                ScriptFileItem item = new ScriptFileItem()
                {
                    FileName = null,
                    DisplayTitle = I18n._("(Select a script file to use)")
                };

                scriptFileList.Add(item);
            }

            if (!Directory.Exists(path))
            {
                return scriptFileList;
            }

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).TrimStart('.').ToLower();

                if (!ApplicationService.Config.IsSupportedFileExtension(extension))
                {
                    continue;
                }

                ScriptFileItem item = new ScriptFileItem()
                {
                    FileName = Path.GetFileName(file),
                    DisplayTitle = Path.GetFileName(file)
                };

                scriptFileList.Add(item);
            }

            return scriptFileList;
        }

        public static string CallScriptInterpreter(ScriptInterpreterItem scriptInterpreter, string scriptFileFullPath, string inputText)
        {
            string programFullPath = ReplaceVariables(scriptInterpreter.ExecutableProgram, scriptFileFullPath);
            if (!File.Exists(programFullPath))
            {
                throw new Exception(String.Format(I18n._("Executable program \"{0}\" does not exist"), programFullPath));
            }

            string programArguments = ReplaceVariables(scriptInterpreter.CommandLineArguments, scriptFileFullPath);

            ScriptFileEmbeddedConfig scriptFileEmbeddedConfig = ParseScriptFileEmbeddedConfig(scriptFileFullPath);

            EncodingType inputEncodingType = StringUtil.GetEfficientEncodingType(scriptInterpreter.InputEncoding, scriptFileEmbeddedConfig.InputEncoding,
                    "inputEncoding");

            EncodingType outputEncodingType = StringUtil.GetEfficientEncodingType(scriptInterpreter.OutputEncoding, scriptFileEmbeddedConfig.OutputEncoding,
                    "outputEncoding");

            Process process = new Process();
            process.StartInfo.FileName = programFullPath;
            process.StartInfo.Arguments = programArguments;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            if (scriptInterpreter.SetPath != null)
            {
                string environmentVariablePath = ReplaceVariables(scriptInterpreter.SetPath, scriptFileFullPath);
                process.StartInfo.EnvironmentVariables["PATH"] = environmentVariablePath;
            }

            int timeout = 3000;

            StringBuilder rawOutputStringBuilder = new StringBuilder();

            AutoResetEvent outputWaitHandle = new AutoResetEvent(false);
            AutoResetEvent errorWaitHandle = new AutoResetEvent(false);

            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    outputWaitHandle.Set();
                }
                else
                {
                    lock (rawOutputStringBuilder)
                    {
                        rawOutputStringBuilder.AppendLine(e.Data);
                    }
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    errorWaitHandle.Set();
                }
                else
                {
                    lock (rawOutputStringBuilder)
                    {
                        rawOutputStringBuilder.AppendLine(e.Data);
                    }
                }
            };

            string stdinString = StringUtil.Encode(inputText, inputEncodingType);

            process.Start();

            process.StandardInput.Write(stdinString);
            process.StandardInput.Close();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            if (process.WaitForExit(timeout)
                    && outputWaitHandle.WaitOne(timeout)
                    && errorWaitHandle.WaitOne(timeout))
            {
                // Process completed. Check process.ExitCode here.
            }
            else
            {
                // Timed out.
            }

            if (!process.HasExited)
            {
                process.Kill();
            }

            string outputText = StringUtil.Decode(rawOutputStringBuilder.ToString(), outputEncodingType);

            return outputText;
        }

        private static string ReplaceVariables(string str, string scriptFileFullPath)
        {
            string scriptFullPath = scriptFileFullPath;
            string scriptBaseName = Path.GetFileName(scriptFileFullPath);
            string scriptExtension = Path.GetExtension(scriptFileFullPath).TrimStart('.');
            string scriptDir = Path.GetDirectoryName(scriptFileFullPath);

            string capDir = FileSystemUtil.GetProgramDirectoryFullPath();

            str = Environment.ExpandEnvironmentVariables(str);

            str = str.Replace("<scriptFullPath>", scriptFileFullPath);
            str = str.Replace("<scriptBaseName>", scriptBaseName);
            str = str.Replace("<scriptExtension>", scriptExtension);
            str = str.Replace("<scriptDir>", scriptDir);

            str = str.Replace("<capDir>", capDir);

            return str;
        }

        private static ScriptFileEmbeddedConfig ParseScriptFileEmbeddedConfig(string scriptFileFullPath)
        {
            ScriptFileEmbeddedConfig result = new ScriptFileEmbeddedConfig();

            // File encoding detect code from http://blog.wudilabs.org/entry/d216f2df/

            bool isUtf8 = true;
            string headText;

            using (FileStream stream = new FileStream(scriptFileFullPath, FileMode.Open, FileAccess.Read,
                    FileShare.Read, 8192, FileOptions.SequentialScan))
            {
                long length = Math.Min(stream.Length, 8192);
                byte[] bytes = new byte[length];
                byte first;
                long pos = 0;
                while (pos < length)
                {
                    first = bytes[pos++] = (byte)stream.ReadByte();
                    if (first < 192)
                    {
                    }
                    else if (first < 224)
                    {
                        if ((length - pos > 1)
                                && (bytes[pos++] = (byte)stream.ReadByte()) < 128)
                        {
                            isUtf8 = false;
                            break;
                        }
                    }
                    else if (first < 240)
                    {
                        if ((length - pos > 2)
                                && !((bytes[pos++] = (byte)stream.ReadByte()) > 127
                                        && (bytes[pos++] = (byte)stream.ReadByte()) > 127))
                        {
                            isUtf8 = false;
                            break;
                        }
                    }
                    else
                    {
                        if ((length - pos > 3)
                                && !((bytes[pos++] = (byte)stream.ReadByte()) > 127
                                        && (bytes[pos++] = (byte)stream.ReadByte()) > 127
                                        && (bytes[pos++] = (byte)stream.ReadByte()) > 127))
                        {
                            isUtf8 = false;
                            break;
                        }
                    }
                }

                headText = isUtf8 ? Encoding.UTF8.GetString(bytes) : Encoding.Default.GetString(bytes);
            }

            headText = headText.Replace("\r\n", "\n").Replace("\r", "");

            int iniSectionLinePos = headText.IndexOf("\n[ClipboardAutoProcessor]\n");
            if (iniSectionLinePos == -1)
            {
                if (headText.IndexOf("[ClipboardAutoProcessor]\n") == 0)
                {
                    iniSectionLinePos = 0;
                }
            }
            else
            {
                iniSectionLinePos++;    // skip leading '\n'
            }

            if (iniSectionLinePos == -1)
            {
                return result;
            }

            StringBuilder embeddedIniStringBuilder = new StringBuilder();

            string[] lines = headText.Substring(iniSectionLinePos).Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (line.Length == 0)
                {
                    break;
                }

                char firstChar = line[0];
                if ((firstChar != '[')
                        && (firstChar != '#')
                        && !char.IsLetter(firstChar))
                {
                    break;
                }

                embeddedIniStringBuilder.AppendLine(line);
            }

            if (lines.Length == 0)
            {
                return result;
            }

            IniOptions iniOptions = new IniOptions()
            {
                Encoding = isUtf8 ? Encoding.UTF8 : Encoding.Default,
                KeySpaceAroundDelimiter = true,
                CommentStarter = IniCommentStarter.Hash     // to prevent MadMilkman.Ini from treating value after semicolon as comment
            };

            IniFile iniFile = new IniFile(iniOptions);
            iniFile.Load(new StringReader(embeddedIniStringBuilder.ToString()));

            result.InputEncoding = iniFile.Sections["ClipboardAutoProcessor"]?.Keys["inputEncoding"]?.Value;
            result.OutputEncoding = iniFile.Sections["ClipboardAutoProcessor"]?.Keys["outputEncoding"]?.Value;

            return result;
        }
    }
}
