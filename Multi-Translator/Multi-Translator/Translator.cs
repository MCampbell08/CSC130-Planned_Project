using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Translator
{
    public class Translator
    {
        private string apiKey = "AIzaSyDF_M6DlvJXlLchm0YF8iHQoxTN-IRSgT8";
        private JObject data = new JObject();
        public void Translate(string inputStream, string source, string target)
        {
            string url = "https://translation.googleapis.com/language/translate/v2";
            url += "?key=" + apiKey;
            url += "&source=" + source;
            url += "&target=" + target;
            url += "&q=" + inputStream;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            data = JObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
        }
        public string DetectLanguage(string inputStream)
        {
            string url = "https://translation.googleapis.com/language/translate/v2/detect";
            url += "?key=" + apiKey;
            url += "&q=" + inputStream;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            WebResponse response = request.GetResponse();

            JObject tempParse = JObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
            JArray parse = JArray.Parse(tempParse["data"]["detections"][0].ToString());
            return parse[0]["language"].ToString(); ;
        }
        public string GetTranslatedText()
        {
            return data["translatedText"].ToString();
        }
    }
}
