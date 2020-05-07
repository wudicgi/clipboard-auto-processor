using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClipboardAutoProcessor.DataStructure;
using IniParser;
using IniParser.Model;

namespace ClipboardAutoProcessor.Util
{
    public static class IniFileUtil
    {
        public static void ParseIniFile<T>(string iniFilePath, T destClassInstance, Action<IniData> extraAction = null)
        {
            FileIniDataParser parser = new FileIniDataParser();
            IniData parsedIniData = ParseIniFile(iniFilePath, parser);

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                IniEntry attribute = propertyInfo.GetCustomAttribute(typeof(IniEntry)) as IniEntry;
                if (attribute == null)
                {
                    continue;
                }

                string stringValue = parsedIniData[attribute.SectionName][attribute.KeyName];
                if (stringValue != null)
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        propertyInfo.SetValue(destClassInstance, stringValue);
                    }
                    else if (propertyInfo.PropertyType == typeof(int))
                    {
                        if (int.TryParse(stringValue, out int intValue))
                        {
                            propertyInfo.SetValue(destClassInstance, intValue);
                        }
                    }
                    else if (propertyInfo.PropertyType == typeof(bool))
                    {
                        if (StringUtil.TryParseBool(stringValue, out bool boolValue))
                        {
                            propertyInfo.SetValue(destClassInstance, boolValue);
                        }
                    }
                }
            }

            extraAction?.Invoke(parsedIniData);
        }

        public static bool WriteIniFile<T>(string iniFilePath, T sourceClassInstance, Action<IniData> extraAction = null)
        {
            FileIniDataParser parser = new FileIniDataParser();
            IniData parsedIniData = ParseIniFile(iniFilePath, parser);

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
                    parsedIniData[attribute.SectionName][attribute.KeyName] = stringValue;
                }
            }

            extraAction?.Invoke(parsedIniData);

            parser.WriteFile(iniFilePath, parsedIniData, Encoding.UTF8);

            return true;
        }

        private static IniData ParseIniFile(string iniFilePath, FileIniDataParser parser)
        {
            if (!File.Exists(iniFilePath))
            {
                return new IniData();
            }

            IniData parsedIniData = parser.ReadFile(iniFilePath, Encoding.UTF8);

            return parsedIniData;
        }
    }
}
