using System;

namespace ClipboardAutoProcessor.DataStructure
{
    public class ScriptInterpreterItem
    {
        /// <summary>
        /// File extension name (without ".", all lower-case)
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// The path of script interpreter executable program
        /// </summary>
        public string ExecutableProgram { get; set; }

        /// <summary>
        /// Command line arguments
        /// </summary>
        public string CommandLineArguments { get; set; }

        /// <summary>
        /// New PATH environment variable value to set (usually something like C:\php;%PATH%)
        /// </summary>
        public string SetPath { get; set; }
    }
}
