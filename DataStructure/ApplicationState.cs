using System;
using System.IO;
using ClipboardAutoProcessor.Util;

namespace ClipboardAutoProcessor.DataStructure
{
    public class ApplicationState
    {
        #region Window

        [IniEntry(SectionName = "window", KeyName = "left")]
        public int WindowLeft { get; set; } = -1;

        [IniEntry(SectionName = "window", KeyName = "top")]
        public int WindowTop { get; set; } = -1;

        [IniEntry(SectionName = "window", KeyName = "width")]
        public int WindowWidth { get; set; } = -1;

        [IniEntry(SectionName = "window", KeyName = "height")]
        public int WindowHeight { get; set; } = -1;

        #endregion

        #region Layout

        [IniEntry(SectionName = "layout", KeyName = "splitterDistance1")]
        public int LayoutSplitterDistance1 { get; set; } = -1;

        [IniEntry(SectionName = "layout", KeyName = "splitterDistance2")]
        public int LayoutSplitterDistance2 { get; set; } = -1;

        #endregion

        #region Control

        [IniEntry(SectionName = "control", KeyName = "autoFetch")]
        public bool ControlAutoFetch { get; set; } = false;

        [IniEntry(SectionName = "control", KeyName = "autoFetchOnlyWhenActivatingForm")]
        public bool ControlAutoFetchOnlyWhenActivatingForm { get; set; } = true;

        [IniEntry(SectionName = "control", KeyName = "autoProcessAfterAutoFetch")]
        public bool ControlAutoProcessAfterAutoFetch { get; set; } = true;

        [IniEntry(SectionName = "control", KeyName = "processedResult1AutoCopy")]
        public bool ControlProcessedResult1AutoCopy { get; set; } = false;

        [IniEntry(SectionName = "control", KeyName = "processedResult1AppendToEnd")]
        public bool ControlProcessedResult1AppendToEnd { get; set; } = false;

        #endregion

        private const string _INI_FILE_NAME = "application_state.ini";

        public static ApplicationState LoadFromFile()
        {
            string iniFileFullPath = FileSystemUtil.GetFullPathBasedOnProgramFile(_INI_FILE_NAME);
            if (!File.Exists(iniFileFullPath))
            {
                return new ApplicationState();
            }

            ApplicationState applicationState = new ApplicationState();
            IniFileUtil.ParseIniFile(iniFileFullPath, applicationState);

            return applicationState;
        }

        public bool Save()
        {
            string iniFileFullPath = FileSystemUtil.GetFullPathBasedOnProgramFile(_INI_FILE_NAME);

            bool succeeded = IniFileUtil.WriteIniFile(iniFileFullPath, this);

            return succeeded;
        }
    }
}
