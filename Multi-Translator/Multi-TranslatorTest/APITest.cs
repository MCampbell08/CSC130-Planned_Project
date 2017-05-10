using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Multi_TranslatorTest
{
    [TestClass]
    public class APITest
    {
        [TestMethod]
        public void ParseTest()
        {
            string expectedData = "{\n  \"data\": {\n    \"translations\": [\n      {\n        \"translatedText\": \"Hola, mi nombre es Bob.\"\n      }\n    ]\n  }\n}\n";
            JObject expectedParsedData = JObject.Parse(expectedData);

            string actualData = new StreamReader("sample.json").ReadToEnd();
            JObject actualParsedData = JObject.Parse(actualData);

            Assert.AreEqual(actualParsedData["translatedText"], expectedParsedData["translatedText"]);
        }
        [TestMethod]
        public void TranslateTest()
        {
            string text = "Hello, my name is Bob.";
            string expected = "{\n  \"data\": {\n    \"translations\": [\n      {\n        \"translatedText\": \"Hola, mi nombre es Bob.\"\n      }\n    ]\n  }\n}\n";
            string actual = "";
            string source = "EN";
            string target = "ES";
            string url = "https://translation.googleapis.com/language/translate/v2?key=AIzaSyDF_M6DlvJXlLchm0YF8iHQoxTN-IRSgT8";
            url += "&source=" + source;
            url += "&target=" + target;
            url += "&q=" + text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            actual = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DetectLanguageTest()
        {
            string text = "Hello, my name is Bob.";
            string expectedLangDetect = "{\n  \"data\": {\n    \"detections\": [\n      [\n        {\n          \"confidence\": 0.2392963171005249,\n          \"isReliable\": false,\n          \"language\": \"en\"\n        }\n      ]\n    ]\n  }\n}\n";
            string actualLangDetect = "en";
            string url = "https://translation.googleapis.com/language/translate/v2/detect";
            url += "?key=AIzaSyDF_M6DlvJXlLchm0YF8iHQoxTN-IRSgT8";
            url += "&q=" + text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            actualLangDetect = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Assert.AreEqual(expectedLangDetect, actualLangDetect);
        }
        [TestMethod]
        public void ReadFromFile()
        {
            FileStream stream = new FileStream("..\\Languages.txt", FileMode.OpenOrCreate);
            if (stream.CanRead && stream != null)
            {
                Assert.IsTrue(stream.CanRead);
                stream.Close();
            }
        }
    }
}