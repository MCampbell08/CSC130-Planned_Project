using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Translator
{
    public class Morse
    {
        Dictionary<char, string> morseCode;
        public void dict()
        {
            char dot = '.';
            char dash = '-';
            morseCode = new Dictionary<char, string>
            {
                {'A', string.Concat(dot, dash)},
                {'B', string.Concat(dash, dot, dot, dot)},
                {'C', string.Concat(dash, dot, dash, dot)},
                {'D', string.Concat(dash, dot, dot)},
                {'E', dot.ToString()},
                {'F', string.Concat(dot, dot, dash, dot)},
                {'G', string.Concat(dash, dash, dot)},
                {'H', string.Concat(dot, dot, dot, dot)},
                {'I', string.Concat(dot, dot)},
                {'J', string.Concat(dot, dash, dash, dash)},
                {'K', string.Concat(dash, dot, dash)},
                {'L', string.Concat(dot, dash, dot, dot)},
                {'M', string.Concat(dash, dash)},
                {'N', string.Concat(dash, dot)},
                {'O', string.Concat(dash, dash, dash)},
                {'P', string.Concat(dot, dash, dash, dot)},
                {'Q', string.Concat(dash, dash, dot, dash)},
                {'R', string.Concat(dot, dash, dot)},
                {'S', string.Concat(dot, dot, dot)},
                {'T', string.Concat(dash)},
                {'U', string.Concat(dot, dot, dash)},
                {'V', string.Concat(dot, dot, dot, dash)},
                {'W', string.Concat(dot, dash, dash)},
                {'X', string.Concat(dash, dot, dot, dash)},
                {'Y', string.Concat(dash, dot, dash, dash)},
                {'Z', string.Concat(dash, dash, dot, dot)},
                {' ', "/" }
            };
        }
        
        public string MorseTranslate(string input)
        {
            dict();
            StringBuilder code = new StringBuilder();
            input = input.ToUpper();
            foreach (char text in input)
            {
                if (morseCode.ContainsKey(text))
                {
                    code.Append(morseCode[text] + " ");
                }
                else if (text == ' ')
                {
                    code.Append("/ ");
                }
                else
                {
                    code.Append(text + " ");
                }
            }
            return code.ToString();
        } 

        public string EnglishTranslate(string input)
        {
            dict();
            StringBuilder english = new StringBuilder();
            string[] letter = input.Split(' ');
            foreach (var l in letter)
            {
                var code = morseCode.FirstOrDefault(x => x.Value == l).Key;
                english.Append(code.ToString());
            }
            return english.ToString();
        }
    }
}
