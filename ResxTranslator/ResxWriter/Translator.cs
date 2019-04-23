using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ResxTranslator
{
    /// <summary>
    /// Translator class responsible for translating the text.
    /// </summary>
    public static class Translator
    {
        private const string KEY = "YOUR_KEY";
        private const string CONTENT_TYPE = "application/json";
        private const string FROM_LANG = "fr";
        private static WebClient webClient = new WebClient { };
        /// <summary>
        /// Translates the given text in the given language.
        /// </summary>
        /// <param name="targetLanguage">Target language.</param>
        /// <param name="value">Text to be translated.</param>
        /// <returns>Translated value of the given text.</returns>
        public static TranslatedResult Translate(Language targetLanguage, string[] text)
        {
            TranslatedResult translatedValue;
            try
            {
                string languagePair = string.Format("{0}", targetLanguage.Value);
                // Get the translated value.
                translatedValue = TranslateText(text, languagePair);

                return translatedValue;
            }
            catch (Exception ex)
            {
                string errorString = "Exception while translating, please check the connectivity." + ex.Message;
                Trace.WriteLine(errorString);
                throw new WebException(errorString);
            }
        }

        #region Get Translated Response from Microsoft Azure API
        /// <summary>
        /// Translate Text Microsoft Azure API
        /// </summary>
        /// <param name="input">The string you want translated</param>
        /// <param name="languagePair">2 letter Language Pair, delimited by "|". 
        /// e.g. "en|da" language pair means to translate from English to Danish</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>Translated to String</returns>
        public static TranslatedResult TranslateText(string[] input, string languagePair)
        {
            if (KEY == "YOUR_KEY")
                throw new Exception("Please get your key from your MS AZURE cognitive service!");

            string url = String.Format("https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to={0}&from={1}", languagePair, FROM_LANG);
            string body = Newtonsoft.Json.JsonConvert.SerializeObject(input.Select(i => new TranslateString(i)));
            webClient.Headers = new WebHeaderCollection{ { "Ocp-Apim-Subscription-Key", KEY }, { "Content-Type", CONTENT_TYPE } };
            string res = webClient.UploadString(url, body);
            

            return Newtonsoft.Json.JsonConvert.DeserializeObject<TranslatedResult[]>(res).FirstOrDefault();
        }
        
        #endregion
        private class TranslateString
        {

            public TranslateString(string text)
            {
                this.Text = WebUtility.UrlEncode(text);
            }

            public string Text { get; set; }
        }

        public class TranslatedResult
        {
            public DetectedLanguage DetectedLanguage { get; set; }

            public Translation[] Translations { get; set; }

            public SentLen SentLen { get; set; }

            public string SourceText { get; set; }

        }

        public class DetectedLanguage
        {
            public string Language { get; set; }
            public float Scrore { get; set; }
        }

        public class Translation
        {
            private string _text;

            public string To { get; set; }
            public string Text { get => _text; set => _text = WebUtility.UrlDecode(value.Replace("% ", "%")).Replace("   ", " "); }
            public Transliteration Transliteration { get; set; }
            public string Alignment { get; set; }

        }
        public class Transliteration
        {
            public ToScript ToScript { get; set; }
        }
        public class ToScript
        {
            public string Script { get; set; }
            public string Text { get; set; }
        }
        public class SentLen
        {
            public int[] SrcSentLen { get; set; }
            public int[] TransSentLen { get; set; }
        }
    }

}