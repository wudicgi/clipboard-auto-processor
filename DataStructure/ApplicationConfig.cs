using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClipboardAutoProcessor.DataStructure
{
    public class ApplicationConfig
    {
        private Dictionary<string, ScriptInterpreterConfig> _scriptInterpreters;

        public ApplicationConfig()
        {
            _scriptInterpreters = new Dictionary<string, ScriptInterpreterConfig>();

            ScriptInterpreterConfig item = new ScriptInterpreterConfig()
            {
                FileExtension = "php",
                ExecutableProgram = @"C:\php\php.exe",
                CommandLineArguments = "-f \"<filename>\" --"
            };
            _scriptInterpreters.Add(item.FileExtension.ToLower(), item);

            ScriptInterpreterConfig item2 = new ScriptInterpreterConfig()
            {
                FileExtension = "js",
                ExecutableProgram = @"cscript.exe",
                CommandLineArguments = "//E:jscript //Nologo \"<filename>\""
            };
            _scriptInterpreters.Add(item2.FileExtension.ToLower(), item2);
        }

        public ScriptInterpreterConfig GetScriptInterpreter(string fileExtension)
        {
            return _scriptInterpreters[fileExtension];
        }

        public bool IsSupportedFileExtension(string fileExtension)
        {
            return _scriptInterpreters.ContainsKey(fileExtension);
        }
    }
}
