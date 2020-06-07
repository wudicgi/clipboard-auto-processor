using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClipboardAutoProcessor.DataStructure;
using ClipboardAutoProcessor.Util;

namespace ClipboardAutoProcessor
{
    public static class ApplicationService
    {
        public const int CLIPBOARD_TEXT_MAX_SUPPORTED_LENGTH = (1024 * 1024);   // 1 MiB

        public static ApplicationConfig Config = ApplicationConfig.LoadFromFile();

        public static ApplicationState State = ApplicationState.LoadFromFile();

        static ApplicationService()
        {
        }

        public static void Init()
        {
            // empty method to trigger loading config files in advance
        }

        public static string GetCurrentVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = versionInfo.FileVersion;

            return version;
        }

        public static string GetCopyrightInformation()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string copyright = versionInfo.LegalCopyright;

            return copyright;
        }
    }
}
