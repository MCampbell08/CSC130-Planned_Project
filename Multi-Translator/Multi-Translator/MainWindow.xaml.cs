using Multi_Translator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Multi_Translator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Language languages = new Language();
        public MainWindow()
        {
            InitializeComponent();
            InitializeLanguages();
        }
        private void InitializeLanguages()
        {
            //Read from file and fill the Languages in the ComboBox on right.
            FileIO fileIo = new FileIO();
            languages.Languages = new Dictionary<string, string>();
            languages.Languages = fileIo.ReadFromFile(languages);
            languages.Languages.Add("Morse", "morse");
            languages.Languages.Add("Binary", "binary");
            languageList_output.ItemsSource = languages.Languages.Keys;
            languageList_output.SelectedIndex = 21;
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {

            Translator trans = new Translator();
            ApiData apiData = new ApiData();
            Morse morse = new Morse();
            Binary binary = new Binary();

            string input = inputText.Text.ToString();
            string targetedLanguage = "en";
            string detectedLanguage = trans.DetectLanguage(input);
            if(detectedLanguage == "und")
            {
                if (input.Contains("1") && input.Contains("0"))
                {
                    detectedLanguage = "bin";
                }
                else if (input.Contains("-") && input.Contains("."))
                {
                    detectedLanguage = "morse";
                }
            }
            foreach (var lang in languages.Languages)
            {
                if (lang.Key == languageList_output.SelectedItem.ToString())
                {
                    if (lang.Key == "Morse")
                    {
                        outputText.Text = morse.MorseTranslate(input);
                        break;
                    }
                    else if (lang.Key == "Binary")
                    {
                        outputText.Text = binary.TranslateToBinary(input);
                        break;
                    }
                    targetedLanguage = lang.Value;
                    trans.Translate(input, detectedLanguage, targetedLanguage);
                    outputText.Text = trans.GetTranslatedText();
                    break;
                }
            }
        }
    }
}
