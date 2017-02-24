using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClipboardAutoProcessor
{
    public class Preferences
    {
        private Dictionary<string, ScriptExecuteCommandLine> m_script_execute_command_lines;

        public Preferences()
        {
            m_script_execute_command_lines = new Dictionary<string, ScriptExecuteCommandLine>();

            ScriptExecuteCommandLine item = new ScriptExecuteCommandLine()
            {
                FileExtension = "php",
                ExecutableProgram = @"C:\php\php.exe",
                CommandLineArguments = "-f \"<filename>\" --"
            };
            m_script_execute_command_lines.Add(item.FileExtension.ToLower(), item);

            ScriptExecuteCommandLine item_2 = new ScriptExecuteCommandLine()
            {
                FileExtension = "js",
                ExecutableProgram = @"cscript.exe",
                CommandLineArguments = "//E:jscript //Nologo \"<filename>\""
            };
            m_script_execute_command_lines.Add(item_2.FileExtension.ToLower(), item_2);
        }

        public ScriptExecuteCommandLine GetScriptExecuteCommandLine(string file_extension)
        {
            return m_script_execute_command_lines[file_extension];
        }

        public bool IsSupportedFileExtension(string file_extension)
        {
            return m_script_execute_command_lines.ContainsKey(file_extension);
        }
    }

    public struct ScriptExecuteCommandLine
    {
        public string FileExtension;
        public string ExecutableProgram;
        public string CommandLineArguments;
    }
}
