using System;

namespace ClipboardAutoProcessor.DataStructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IniEntry : Attribute
    {
        public string SectionName { get; set; } = null;

        public string KeyName { get; set; } = null;
    }
}
