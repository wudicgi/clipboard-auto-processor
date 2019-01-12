using ClipboardAutoProcessor.Properties;
using NGettext;
using NGettext.Loaders;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace ClipboardAutoProcessor
{
    public static class I18n
    {
        private static ICatalog _catalog;

        static I18n()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyName = assembly.GetName().Name;

            CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;
            string languageTag = currentCultureInfo.IetfLanguageTag.Replace('-', '_');

            string moFileResourceName = assemblyName + ".locale." + languageTag + ".message.mo";

            Stream stream = assembly.GetManifestResourceStream(moFileResourceName);
            if (stream == null)
            {
                _catalog = new Catalog();
            }
            else
            {
                _catalog = new Catalog(new MoLoader(stream));
            }
        }

        public static string _(string text)
        {
            return _catalog.GetString(text);
        }
    }
}
