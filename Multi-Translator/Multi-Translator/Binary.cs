using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Translator
{
    public class Binary
    {
        public string TranslateToBinary(string input)
        {
            string result = "";

            foreach (char letter in input.ToCharArray())
            {
                result += Convert.ToString(letter, 2).PadLeft(8, '0');
                result += " ";
            }
            return result;
        }

        //public string TranslateToEnglish(string input)
        //{

        //}
    }
}
