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
        public static T ParseIniFile<T>(string iniFilePath)
            where T : new()
        {
            T result = new T();

            FileIniDataParser parser = new FileIniDataParser();

            IniData parsedIniData;
            if ((iniFilePath != null) && File.Exists(iniFilePath))
            {
                parsedIniData = parser.ReadFile(iniFilePath, Encoding.UTF8);
            }
            else
            {
                parsedIniData = new IniData();
            }

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
                        propertyInfo.SetValue(result, stringValue);
                    }
                    else if (propertyInfo.PropertyType == typeof(int))
                    {
                        if (int.TryParse(stringValue, out int intValue))
                        {
                            propertyInfo.SetValue(result, intValue);
                        }
                    }
                    else if (propertyInfo.PropertyType == typeof(bool))
                    {
                        if (StringUtil.TryParseBool(stringValue, out bool boolValue))
                        {
                            propertyInfo.SetValue(result, boolValue);
                        }
                    }
                }
            }

            return result;
        }

        public static bool WriteIniFile<T>(string iniFilePath, T classInstance)
        {
            FileIniDataParser parser = new FileIniDataParser();

            IniData parsedIniData;
            if (File.Exists(iniFilePath))
            {
                parsedIniData = parser.ReadFile(iniFilePath, Encoding.UTF8);
            }
            else
            {
                parsedIniData = new IniData();
            }

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                IniEntry attribute = propertyInfo.GetCustomAttribute(typeof(IniEntry)) as IniEntry;
                if (attribute == null)
                {
                    continue;
                }

                object objectValue = propertyInfo.GetValue(classInstance);

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

            parser.WriteFile(iniFilePath, parsedIniData, Encoding.UTF8);

            return true;
        }
    }
}
