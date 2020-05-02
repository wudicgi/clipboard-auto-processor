using System;

namespace ClipboardAutoProcessor.DataStructure
{
    public class HistoryOperationItem
    {
        /// <summary>
        /// The item text to display in combo box
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Operation type ("Auto" or "Manual")
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Script execution completion time
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Truncated beginning text of ClipboardText
        /// </summary>
        public string SummaryText { get; set; }

        public string ClipboardText { get; set; }
        public string ProcessResult1 { get; set; }
        public string ProcessResult2 { get; set; }
        public string Script1 { get; set; }
        public string Script2 { get; set; }
    }
}
