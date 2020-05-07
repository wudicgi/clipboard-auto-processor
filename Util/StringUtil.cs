using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardAutoProcessor.Util
{
    public static class StringUtil
    {
        public static string Base64Encode(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            return Convert.ToBase64String(bytes);
        }

        public static string Base64Decode(string text)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(text);

                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception)
            {
                return text;
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
    }
}
