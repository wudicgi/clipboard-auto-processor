using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClipboardAutoProcessor.DataStructure;
using MadMilkman.Ini;

namespace ClipboardAutoProcessor.Util
{
    public static class IniFileUtil
    {
        public static void ParseIniFile<T>(string iniFilePath, T destClassInstance, Action<IniFile> extraAction = null)
        {
            IniFile iniFile = LoadIniFile(iniFilePath);

            foreach (IniSection iniSection in iniFile.Sections)
            {
                string sectionName = iniSection.Name;

                foreach (IniKey iniKey in iniSection.Keys)
                {
                    string keyName = iniKey.Name;
                    string keyValue = iniKey.Value;

                    foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                    {
                        IniEntry attribute = propertyInfo.GetCustomAttribute(typeof(IniEntry)) as IniEntry;
                        if (attribute == null)
                        {
                            continue;
                        }

                        if ((attribute.SectionName == sectionName) && (attribute.KeyName == keyName))
                        {
                            if (propertyInfo.PropertyType == typeof(string))
                            {
                                propertyInfo.SetValue(destClassInstance, keyValue);
                            }
                            else if (propertyInfo.PropertyType == typeof(int))
                            {
                                if (int.TryParse(keyValue, out int intValue))
                                {
                                    propertyInfo.SetValue(destClassInstance, intValue);
                                }
                            }
                            else if (propertyInfo.PropertyType == typeof(bool))
                            {
                                if (StringUtil.TryParseBool(keyValue, out bool boolValue))
                                {
                                    propertyInfo.SetValue(destClassInstance, boolValue);
                                }
                            }
                        }
                    }
                }
            }

            extraAction?.Invoke(iniFile);
        }

        public static bool WriteIniFile<T>(string iniFilePath, T sourceClassInstance, Action<IniFile> extraAction = null)
        {
            IniFile iniFile = LoadIniFile(iniFilePath);

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                IniEntry attribute = propertyInfo.GetCustomAttribute(typeof(IniEntry)) as IniEntry;
                if (attribute == null)
                {
                    continue;
                }

                object objectValue = propertyInfo.GetValue(sourceClassInstance);

                string stringValue = null;
                if (objectValue is string)
                {
                    stringValue = (string)objectValue;
                }
                else if (objectValue is int)
                {
                    stringValue = ((int)objectValue).ToString();
                }
                else if (objectValue is bool)
                {
                    stringValue = ((bool)objectValue) ? "true" : "false";
                }

                if (stringValue != null) {
                    SetKeyValue(iniFile, attribute.SectionName, attribute.KeyName, stringValue);
                }
            }

            extraAction?.Invoke(iniFile);

            iniFile.Save(iniFilePath);

            return true;
        }

        private static IniFile LoadIniFile(string iniFilePath)
        {
            IniOptions iniOptions = new IniOptions()
            {
                Encoding = Encoding.UTF8,
                KeySpaceAroundDelimiter = true,
                CommentStarter = IniCommentStarter.Hash     // to prevent MadMilkman.Ini from treating value after semicolon as comment
            };

            IniFile iniFile = new IniFile(iniOptions);

            if (File.Exists(iniFilePath))
            {
                iniFile.Load(iniFilePath);
            }

            return iniFile;
        }

        public static IniSection AddSection(IniFile iniFile, string sectionName)
        {
            IniSection iniSection = new IniSection(iniFile, sectionName);

            if (iniFile.Sections.Count != 0)
            {
                iniSection.LeadingComment.EmptyLinesBefore = 1;
            }

            iniFile.Sections.Add(iniSection);

            return iniSection;
        }

        public static void SetKeyValue(IniFile iniFile, string sectionName, string keyName, string keyValue)
        {
            IniSection iniSection;
            if (iniFile.Sections.Contains(sectionName))
            {
                iniSection = iniFile.Sections[sectionName];
            } else {
                iniSection = AddSection(iniFile, sectionName);
            }

            SetKeyValue(iniSection, keyName, keyValue);
        }

        public static void SetKeyValue(IniSection iniSection, string keyName, string keyValue)
        {
            if (iniSection.Keys.Contains(keyName))
            {
                iniSection.Keys[keyName].Value = keyValue;
            } else {
                iniSection.Keys.Add(keyName, keyValue);
            }
        }
    }
}
