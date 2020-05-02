using System;

namespace ClipboardAutoProcessor.DataStructure
{
    public class ScriptFileItem
    {
        /// <summary>
        /// The full path of the script file
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The base name of the script file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The title text to display in combo box
        /// </summary>
        public string DisplayTitle { get; set; }
    }
}
