using System;

namespace ClipboardAutoProcessor.DataStructure
{
    public class HistoryState
    {
        public string Text { get; set; }

        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string SummaryText { get; set; }

        public string ClipboardText { get; set; }
        public string ProcessResult1 { get; set; }
        public string ProcessResult2 { get; set; }
        public string Script1 { get; set; }
        public string Script2 { get; set; }
    }
}
