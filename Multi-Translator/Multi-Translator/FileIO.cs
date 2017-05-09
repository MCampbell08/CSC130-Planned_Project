using Multi_Translator.Models;
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
        public Dictionary<string,string> ReadFromFile(Language language)
        {
            string fileLine = "";
            using (StreamReader file = new StreamReader("Languages.txt"))
                while (!file.EndOfStream)
                {
                    fileLine = file.ReadLine();
                    var items = fileLine.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new[] { '=' }));
                    foreach (var item in items)
                    {
                        language.Languages.Add(item[0], item[1]);
                    }
                }
            return language.Languages;
        }
    }
}
