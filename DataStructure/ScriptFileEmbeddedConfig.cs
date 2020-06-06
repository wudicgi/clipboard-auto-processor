using System;

namespace ClipboardAutoProcessor.DataStructure
{
    public class ScriptFileEmbeddedConfig
    {
        /// <summary>
        /// Encoding type to encode the input text writing to stdin
        /// </summary>
        public string InputEncoding { get; set; } = null;

        /// <summary>
        /// Encoding type to decode the output text reading from stdout
        /// </summary>
        public string OutputEncoding { get; set; } = null;
    }
}
