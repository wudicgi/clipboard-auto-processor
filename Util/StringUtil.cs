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
    }
}
