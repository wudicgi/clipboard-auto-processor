using System;
using System.IO;
using ClipboardAutoProcessor.Util;

namespace ClipboardAutoProcessor.DataStructure
{
    public class ApplicationState
    {
        #region Window

        [IniEntry(SectionName = "window", KeyName = "state")]
        public string Window_State { get; set; } = string.Empty;

        [IniEntry(SectionName = "window", KeyName = "left")]
        public int Window_Left { get; set; } = -1;

        [IniEntry(SectionName = "window", KeyName = "top")]
        public int Window_Top { get; set; } = -1;

        [IniEntry(SectionName = "window", KeyName = "width")]
        public int Window_Width { get; set; } = -1;

        [IniEntry(SectionName = "window", KeyName = "height")]
        public int Window_Height { get; set; } = -1;

        #endregion

        #region Layout

        [IniEntry(SectionName = "layout", KeyName = "splitterDistance1")]
        public int Layout_SplitterDistance1 { get; set; } = -1;

        [IniEntry(SectionName = "layout", KeyName = "splitterDistance2")]
        public int Layout_SplitterDistance2 { get; set; } = -1;

        #endregion

        #region Control

        [IniEntry(SectionName = "control", KeyName = "selectedScriptFileName1")]
        public string Control_SelectedScriptFileName1 { get; set; } = string.Empty;

        [IniEntry(SectionName = "control", KeyName = "selectedScriptFileName2")]
        public string Control_SelectedScriptFileName2 { get; set; } = string.Empty;

        [IniEntry(SectionName = "control", KeyName = "autoFetch")]
        public bool Control_AutoFetch { get; set; } = false;

        [IniEntry(SectionName = "control", KeyName = "autoFetchOnlyWhenActivatingForm")]
        public bool Control_AutoFetchOnlyWhenActivatingForm { get; set; } = true;

        [IniEntry(SectionName = "control", KeyName = "autoProcessAfterAutoFetch")]
        public bool Control_AutoProcessAfterAutoFetch { get; set; } = true;

        [IniEntry(SectionName = "control", KeyName = "processedResult1AutoCopy")]
        public bool Control_ProcessedResult1AutoCopy { get; set; } = false;

        [IniEntry(SectionName = "control", KeyName = "processedResult1AppendToEnd")]
        public bool Control_ProcessedResult1AppendToEnd { get; set; } = false;

        [IniEntry(SectionName = "control", KeyName = "processedResult2AutoCopy")]
        public bool Control_ProcessedResult2AutoCopy { get; set; } = false;

        [IniEntry(SectionName = "control", KeyName = "processedResult2AppendToEnd")]
        public bool Control_ProcessedResult2AppendToEnd { get; set; } = false;

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
