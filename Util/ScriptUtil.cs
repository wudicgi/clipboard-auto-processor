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

        public static string CallScriptInterpreter(ScriptInterpreterItem scriptInterpreter, string scriptFileFullpath, string inputText)
        {
            Process process = new Process();
            process.StartInfo.FileName = scriptInterpreter.ExecutableProgram.Replace("<filename>", scriptFileFullpath);
            process.StartInfo.Arguments = scriptInterpreter.CommandLineArguments.Replace("<filename>", scriptFileFullpath);
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            if (scriptInterpreter.AdditionalPath != null)
            {
                string environmentVariablePath = (process.StartInfo.EnvironmentVariables.ContainsKey("PATH") ?
                        (process.StartInfo.EnvironmentVariables["PATH"] + ";") : "") + scriptInterpreter.AdditionalPath;
                process.StartInfo.EnvironmentVariables["PATH"] = environmentVariablePath;
            }

            int timeout = 3000;

            StringBuilder stdout = new StringBuilder();
            StringBuilder stderr = new StringBuilder();

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
                    stdout.AppendLine(e.Data);
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
                    stderr.AppendLine(e.Data);
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

            string outputText = StringUtil.Base64Decode(stdout.ToString());

            return outputText;
        }
    }
}
