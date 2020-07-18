using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClipboardAutoProcessor.Util;
using MadMilkman.Ini;

namespace ClipboardAutoProcessor.DataStructure
{
    public class ApplicationConfig
    {
        private const string _INI_SECTION_NAME_SCRIPT_INTERPRETER = "scriptInterpreter";

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

        private const string _INI_FILE_NAME = "config.ini";

        private const string _DEFAULT_INI_FILE_NAME_ZH_CN = "config.default.zh-CN.ini";

        private const string _DEFAULT_INI_FILE_NAME_EN_US = "config.default.en-US.ini";

        public Dictionary<string, ScriptInterpreterItem> ScriptInterpreters = new Dictionary<string, ScriptInterpreterItem>();

        public static ApplicationConfig LoadFromFile()
        {
            string iniFileFullPath = FileSystemUtil.GetFullPathBasedOnProgramFile(_INI_FILE_NAME);
            if (!File.Exists(iniFileFullPath))
            {
                CreateDefault(iniFileFullPath);
            }

            ApplicationConfig applicationConfig = new ApplicationConfig();
            IniFileUtil.ParseIniFile(iniFileFullPath, applicationConfig, (iniFile) =>
            {
                foreach (IniSection iniSection in iniFile.Sections)
                {
                    string sectionName = iniSection.Name;
                    if (sectionName != _INI_SECTION_NAME_SCRIPT_INTERPRETER)
                    {
                        continue;
                    }

                    string extension = iniSection.Keys["extension"]?.Value;
                    string program = iniSection.Keys["program"]?.Value;
                    string arguments = iniSection.Keys["arguments"]?.Value;
                    string setPath = iniSection.Keys["setPath"]?.Value;
                    string inputEncoding = iniSection.Keys["inputEncoding"]?.Value;
                    string outputEncoding = iniSection.Keys["outputEncoding"]?.Value;

                    if (extension == null || program == null || arguments == null)
                    {
                        continue;
                    }

                    ScriptInterpreterItem item = new ScriptInterpreterItem()
                    {
                        FileExtension = extension,
                        ExecutableProgram = program,
                        CommandLineArguments = arguments,
                        SetPath = setPath,
                        InputEncoding = inputEncoding,
                        OutputEncoding = outputEncoding
                    };

                    applicationConfig.ScriptInterpreters.Add(item.FileExtension.ToLower(), item);
                }
            });

            return applicationConfig;
        }

        private static void CreateDefault(string iniFileFullPath)
        {
            System.Globalization.CultureInfo currentUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture;

            string defaultIniFileName = (currentUICulture.TwoLetterISOLanguageName == "zh")
                    ? _DEFAULT_INI_FILE_NAME_ZH_CN : _DEFAULT_INI_FILE_NAME_EN_US;

            string defaultIniFileFullPath = FileSystemUtil.GetFullPathBasedOnProgramFile(defaultIniFileName);

            try
            {
                byte[] data = File.ReadAllBytes(defaultIniFileFullPath);
                File.WriteAllBytes(iniFileFullPath, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        String.Format(I18n._("Error occurred while creating default config file:\n{0}")
                                .Replace("\n", Environment.NewLine), ex.Message),
                        I18n._("Clipboard Auto Processor"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
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
