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
        public static ApplicationConfig Config = new ApplicationConfig();

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
