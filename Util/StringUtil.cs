using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClipboardAutoProcessor.DataStructure;

namespace ClipboardAutoProcessor.Util
{
    public static class StringUtil
    {
        public static string Encode(string text, EncodingType encodingType)
        {
            switch (encodingType)
            {
                case EncodingType.SystemDefault:
                    return text;

                case EncodingType.Base64_SystemDefault:
                    return Convert.ToBase64String(Encoding.Default.GetBytes(text)) + Environment.NewLine;

                case EncodingType.Base64_UTF8:
                    return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)) + Environment.NewLine;

                default:
                    return text;
            }
        }

        public static string Decode(string text, EncodingType encodingType)
        {
            switch (encodingType)
            {
                case EncodingType.SystemDefault:
                    return text;

                case EncodingType.Base64_SystemDefault:
                    try
                    {
                        byte[] bytes = Convert.FromBase64String(text);
                        return Encoding.Default.GetString(bytes);
                    }
                    catch (Exception)
                    {
                        return text;
                    }

                case EncodingType.Base64_UTF8:
                    try
                    {
                        byte[] bytes = Convert.FromBase64String(text);
                        return Encoding.UTF8.GetString(bytes);
                    }
                    catch (Exception)
                    {
                        return text;
                    }

                default:
                    return text;
            }
        }

        public static EncodingType GetEfficientEncodingType(string scriptInterpreterEncodingTypeString, string fileEncodingTypeString, string parameterName)
        {
            if (!string.IsNullOrEmpty(fileEncodingTypeString))
            {
                EncodingType result = ParseEncodingType(fileEncodingTypeString);

                if (result == EncodingType.Unknown)
                {
                    throw new Exception(String.Format(I18n._("Invalid {0} value in script file embedded config: \"{1}\""),
                            parameterName, fileEncodingTypeString));
                }

                return result;
            }

            if (!string.IsNullOrEmpty(scriptInterpreterEncodingTypeString))
            {
                EncodingType result = ParseEncodingType(scriptInterpreterEncodingTypeString);

                if (result == EncodingType.Unknown)
                {
                    throw new Exception(String.Format(I18n._("Invalid {0} value in script interpreter config: \"{1}\""),
                            parameterName, scriptInterpreterEncodingTypeString));
                }

                return result;
            }

            return EncodingType.SystemDefault;
        }

        public static EncodingType ParseEncodingType(string str)
        {
            switch (str.Trim().ToLower())
            {
                case "systemdefault":
                case "default":
                    return EncodingType.SystemDefault;

                case "base64_systemdefault":
                case "base64_default":
                    return EncodingType.Base64_SystemDefault;

                case "base64_utf8":
                    return EncodingType.Base64_UTF8;

                default:
                    return EncodingType.Unknown;
            }
        }

        public static bool TryParseBool(string s, out bool result)
        {
            if (bool.TryParse(s, out result))
            {
                return true;
            }
            else
            {
                s = s.Trim();

                if (s == "1")
                {
                    result = true;
                }
                else if (s == "0")
                {
                    result = false;
                }
                else if (s != "")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                return true;
            }
        }

        public static bool HasLfLineEnding(string text)
        {
            if (text.Length == 0)
            {
                return false;
            }

            if (text.Length == 1)
            {
                return (text == "\n");
            }

            int startIndex = 1;
            int lfIndex;
            while ((lfIndex = text.IndexOf('\n', startIndex)) > 0)
            {
                if (text[lfIndex - 1] != '\r')
                {
                    return true;
                }

                startIndex = lfIndex + 1;
            }

            return false;
        }

        public static string NormalizeLineEndingToCrLf(string text)
        {
            string newText = text.Replace("\r\n", "\n").Replace("\n", "\r\n");

            return newText;
        }
    }
}
