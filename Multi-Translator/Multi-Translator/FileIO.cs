using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Translator
{
    public class FileIO
    {
        public Dictionary<string,string> ReadFromFile()
        {
            Dictionary<string, string> language = new Dictionary<string, string>();
            string fileLine = "";
            using (StreamReader file = new StreamReader("C:..\\Languages.txt"))
                while (!file.EndOfStream)
                {
                    fileLine = file.ReadLine();
                    var items = fileLine.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new[] { '=' }));
                    foreach (var item in items)
                    {
                        language.Add(item[0], item[1]);
                    }
                }
            return language;
        }
    }
}
