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

        [IniEntry(SectionName = "userInterface", KeyName = "textareaLineEnding")]
        public string UserInterface_TextareaLineEnding { get; set; } = "normalizeToCrLf";

        #endregion

        #region Dir Path

        [IniEntry(SectionName = "dirPath", KeyName = "scriptDir1")]
        public string DirPath_ScriptDir1 { get; set; } = "scripts";

        [IniEntry(SectionName = "dirPath", KeyName = "scriptDir2")]
        public string DirPath_ScriptDir2 { get; set; } = "scripts2";

        #endregion

        private const string _INI_FILE_NAME = "application_config.ini";

        public Dictionary<string, ScriptInterpreterItem> ScriptInterpreters = new Dictionary<string, ScriptInterpreterItem>();

        public static ApplicationConfig LoadFromFile()
        {
            string iniFileFullPath = FileSystemUtil.GetFullPathBasedOnProgramFile(_INI_FILE_NAME);
            if (!File.Exists(iniFileFullPath))
            {
                CreateDefault(iniFileFullPath);
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

        private static void CreateDefault(string iniFileFullPath)
        {
            ApplicationConfig applicationConfig = new ApplicationConfig();

            ScriptInterpreterItem defaultScriptInterpreterItem = new ScriptInterpreterItem()
            {
                FileExtension = "php",
                ExecutableProgram = @"C:\php\php.exe",
                CommandLineArguments = "-f \"<filename>\" --",
                AdditionalPath = @"C:\php"
            };
            applicationConfig.ScriptInterpreters.Add(defaultScriptInterpreterItem.FileExtension.ToLower(), defaultScriptInterpreterItem);

            IniFileUtil.WriteIniFile(iniFileFullPath, applicationConfig, (parsedIniData) =>
            {
                foreach (string key in applicationConfig.ScriptInterpreters.Keys)
                {
                    ScriptInterpreterItem item = applicationConfig.ScriptInterpreters[key];
                    if (item.FileExtension == null)
                    {
                        continue;
                    }

                    string iniSectionName = "scriptInterpreter." + item.FileExtension.ToLower();

                    if (item.FileExtension != null)
                    {
                        parsedIniData[iniSectionName]["extension"] = item.FileExtension;
                    }
                    if (item.ExecutableProgram != null)
                    {
                        parsedIniData[iniSectionName]["program"] = item.ExecutableProgram;
                    }
                    if (item.CommandLineArguments != null)
                    {
                        parsedIniData[iniSectionName]["arguments"] = item.CommandLineArguments;
                    }
                    if (item.AdditionalPath != null)
                    {
                        parsedIniData[iniSectionName]["additionalPath"] = item.AdditionalPath;
                    }
                }
            });
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
