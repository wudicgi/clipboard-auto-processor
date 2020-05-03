using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ClipboardAutoProcessor.Util;
using IniParser;
using IniParser.Model;

namespace ClipboardAutoProcessor.DataStructure
{
    public class ApplicationConfig
    {
        public const int CLIPBOARD_TEXT_MAX_SUPPORTED_LENGTH = (1024 * 1024);   // 1 MiB

        private const string _SCRIPT_INTERPRETERS_INI_FILE_NAME = "script_interpreters.ini";

        private Dictionary<string, ScriptInterpreterItem> _scriptInterpreters = new Dictionary<string, ScriptInterpreterItem>();

        public ApplicationConfig()
        {
            LoadScriptInterpreters();
        }

        public void LoadScriptInterpreters()
        {
            string iniFileFullPath = FileSystemUtil.GetFullPathBasedOnProgramFile(_SCRIPT_INTERPRETERS_INI_FILE_NAME);
            if (!File.Exists(iniFileFullPath))
            {
                File.WriteAllText(iniFileFullPath, string.Empty);
            }

            FileIniDataParser parser = new FileIniDataParser();
            IniData parsedIniData = parser.ReadFile(iniFileFullPath, Encoding.UTF8);

            foreach (SectionData sectionData in parsedIniData.Sections)
            {
                string extension = sectionData.Keys["extension"];
                string program = sectionData.Keys["program"];
                string arguments = sectionData.Keys["arguments"];

                if (extension == null || program == null || arguments == null)
                {
                    continue;
                }

                ScriptInterpreterItem item = new ScriptInterpreterItem()
                {
                    FileExtension = extension,
                    ExecutableProgram = program,
                    CommandLineArguments = arguments
                };

                _scriptInterpreters.Add(item.FileExtension.ToLower(), item);
            }
        }

        public ScriptInterpreterItem GetScriptInterpreter(string fileExtension)
        {
            return _scriptInterpreters[fileExtension];
        }

        public bool IsSupportedFileExtension(string fileExtension)
        {
            return _scriptInterpreters.ContainsKey(fileExtension);
        }
    }
}
