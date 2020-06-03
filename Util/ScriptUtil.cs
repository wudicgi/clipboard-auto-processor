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
            Process process = new Process();
            process.StartInfo.FileName = ReplaceVariables(scriptInterpreter.ExecutableProgram, scriptFileFullPath);
            process.StartInfo.Arguments = ReplaceVariables(scriptInterpreter.CommandLineArguments, scriptFileFullPath);
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

            StringBuilder rawOutputString = new StringBuilder();

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
                    rawOutputString.AppendLine(e.Data);
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
                    rawOutputString.AppendLine(e.Data);
                }
            };

            process.Start();

            process.StandardInput.WriteLine(StringUtil.Base64Encode(inputText));
            process.StandardInput.Close();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            if (process.WaitForExit(timeout) &&
                    outputWaitHandle.WaitOne(timeout) &&
                    errorWaitHandle.WaitOne(timeout))
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

            string outputText = StringUtil.Base64Decode(rawOutputString.ToString());

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
    }
}
