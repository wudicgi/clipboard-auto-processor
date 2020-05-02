using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClipboardAutoProcessor
{
    public class ApplicationConfig
    {
        private Dictionary<string, ScriptExecuteCommandLine> _scriptExecuteCommandLines;

        public ApplicationConfig()
        {
            _scriptExecuteCommandLines = new Dictionary<string, ScriptExecuteCommandLine>();

            ScriptExecuteCommandLine item = new ScriptExecuteCommandLine()
            {
                FileExtension = "php",
                ExecutableProgram = @"C:\php\php.exe",
                CommandLineArguments = "-f \"<filename>\" --"
            };
            _scriptExecuteCommandLines.Add(item.FileExtension.ToLower(), item);

            ScriptExecuteCommandLine item2 = new ScriptExecuteCommandLine()
            {
                FileExtension = "js",
                ExecutableProgram = @"cscript.exe",
                CommandLineArguments = "//E:jscript //Nologo \"<filename>\""
            };
            _scriptExecuteCommandLines.Add(item2.FileExtension.ToLower(), item2);
        }

        public ScriptExecuteCommandLine GetScriptExecuteCommandLine(string fileExtension)
        {
            return _scriptExecuteCommandLines[fileExtension];
        }

        public bool IsSupportedFileExtension(string fileExtension)
        {
            return _scriptExecuteCommandLines.ContainsKey(fileExtension);
        }
    }

    public struct ScriptExecuteCommandLine
    {
        public string FileExtension;
        public string ExecutableProgram;
        public string CommandLineArguments;
    }
}
