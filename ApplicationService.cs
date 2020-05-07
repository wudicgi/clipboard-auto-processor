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
    }
}
