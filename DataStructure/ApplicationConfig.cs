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
        #region User Interface

        [IniEntry(SectionName = "userInterface", KeyName = "displayLanguage")]
        public string UserInterface_DisplayLanguage { get; set; } = "auto";

        [IniEntry(SectionName = "userInterface", KeyName = "textareaFontName")]
        public string UserInterface_TextareaFontName { get; set; } = string.Empty;

        [IniEntry(SectionName = "userInterface", KeyName = "textareaFontSize")]
        public string UserInterface_TextareaFontSize { get; set; } = string.Empty;

        #endregion

        #region Dir Path

        [IniEntry(SectionName = "dirPath", KeyName = "scriptDir1")]
        public string DirPath_ScriptDir1 { get; set; } = string.Empty;

        [IniEntry(SectionName = "dirPath", KeyName = "scriptDir2")]
        public string DirPath_ScriptDir2 { get; set; } = string.Empty;

        #endregion

        private const string _INI_FILE_NAME = "application_config.ini";

        public Dictionary<string, ScriptInterpreterItem> ScriptInterpreters = new Dictionary<string, ScriptInterpreterItem>();

        public static ApplicationConfig LoadFromFile()
        {
            string iniFileFullPath = FileSystemUtil.GetFullPathBasedOnProgramFile(_INI_FILE_NAME);
            if (!File.Exists(iniFileFullPath))
            {
                File.WriteAllText(iniFileFullPath, string.Empty);
            }

            ApplicationConfig applicationConfig = new ApplicationConfig();
            IniFileUtil.ParseIniFile(iniFileFullPath, applicationConfig, (parsedIniData) =>
            {
                foreach (SectionData sectionData in parsedIniData.Sections)
                {
                    if (!sectionData.SectionName.StartsWith("scriptInterpreter."))
                    {
                        continue;
                    }

                    string extension = sectionData.Keys["extension"];
                    string program = sectionData.Keys["program"];
                    string arguments = sectionData.Keys["arguments"];
                    string additionalPath = sectionData.Keys["additionalPath"];

                    if (extension == null || program == null || arguments == null)
                    {
                        continue;
                    }

                    ScriptInterpreterItem item = new ScriptInterpreterItem()
                    {
                        FileExtension = extension,
                        ExecutableProgram = program,
                        CommandLineArguments = arguments,
                        AdditionalPath = additionalPath
                    };

                    applicationConfig.ScriptInterpreters.Add(item.FileExtension.ToLower(), item);
                }
            });

            return applicationConfig;
        }

        public ScriptInterpreterItem GetScriptInterpreter(string fileExtension)
        {
            return ScriptInterpreters[fileExtension];
        }

        public bool IsSupportedFileExtension(string fileExtension)
        {
            return ScriptInterpreters.ContainsKey(fileExtension);
        }
    }
}
