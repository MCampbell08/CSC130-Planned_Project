using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multi_Translator;

namespace Multi_TranslatorTest
{
    [TestClass]
    public class MorseAndBinary
    {
        [TestMethod]
        public void MorseCodeTest()
        {
            Morse morse = new Morse();
            string input = "e";
            string expected = ". ";
            string actual = morse.MorseTranslate(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BinaryCodeTest()
        {
            Binary binary = new Binary();
            string input = "e";
            string expected = "01100101";
            string actual = binary.TranslateToBinary(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
