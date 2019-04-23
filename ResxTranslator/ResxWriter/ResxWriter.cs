using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Resources;
using System.Collections;
using System.IO;
using System.Threading;

namespace ResxTranslator
{
    /// <summary>
    /// ResxWriter class responsible for adding the strings in target resx file.
    /// </summary>
    public static class ResxWriter
    {
        /// <summary>
        /// Translates the given resx in the specified language. new language resx
        /// file will be created in the same folder and with the same name suffixed with
        /// the locale name.
        /// </summary>
        /// <param name="targetLanguage">Language in which text to be translated.</param>
        /// <param name="resxFilePath">Source resx file path</param>
        public static void Write(Language targetLanguage, string resxFilePath, bool onlyTextStrings)
        {
            if (string.IsNullOrEmpty(resxFilePath))
            {
                throw new ArgumentNullException(resxFilePath, "Resx file path cannot be null or empty");
            }
            if (targetLanguage == null)
            {
                throw new ArgumentNullException(targetLanguage, "Target Language cannot be null");
            }

            using (ResXResourceReader resourceReader = new ResXResourceReader(resxFilePath))
            {
                //string locale = targetLanguage.ToString().Substring(0, 2).ToLower();
                string locale = targetLanguage.Value.ToLower();

                #region Create locale specific directory.
                //string outputFilePath = Path.Combine(Path.GetDirectoryName(ResxFilePath), locale);
                //if (!Directory.Exists(outputFilePath))
                //{
                //    Directory.CreateDirectory(outputFilePath);
                //} 
                #endregion

                // Create the required file name with locale.
                string outputFilePath = Path.GetDirectoryName(resxFilePath);
                string outputFileName = Path.GetFileNameWithoutExtension(resxFilePath);
                outputFileName += "." + locale + ".resx";
                outputFilePath = Path.Combine(outputFilePath, outputFileName);

                // Create a resx writer.
                using (ResXResourceWriter resourceWriter = new ResXResourceWriter(outputFilePath))
                {
                    foreach (DictionaryEntry entry in resourceReader)
                    {
                        string key = entry.Key as string;
                        // Check if the Key is UI Text element.
                        if (!String.IsNullOrEmpty(key) && !key.StartsWith(">>"))
                        {
                            if (onlyTextStrings)
                            {
                                if (!key.EndsWith(".Text"))
                                {
                                    continue;
                                }
                            }
                            string value = entry.Value as string;

                            // check for null or empty
                            if (!String.IsNullOrEmpty(value))
                            {
                                var val = Translator.Translate(targetLanguage, new string[] { value })?.Translations[0]?.Text;
                                // Get the translated value.
                                if (val != null)
                                    resourceWriter.AddResource(key, val);
                                Thread.Sleep(500);
                            }
                        }
                    }
                    // Generate resx file.
                    resourceWriter.Generate();
                }
            }
        }
    }
}
