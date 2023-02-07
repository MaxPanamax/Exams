using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Dictionary
{
     class Methods
     {
        public static void All_words()
        {
            try
            {
                var listWord = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml")).Descendants("Word")

                               select new Word
                               {

                                   RusWord = word.Element("RusWord").Value.ToString(),
                                   EngWord = word.Element("EngWord").Value.ToString()

                               };


                foreach (var item in listWord)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(item.EngWord+"-"+item.RusWord);
                }

            }
            catch (Exception exp)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("нет слов в каталоге");
            }

        }
        public static void Translation(string _Word)
        {
            try
            {
                var listWord = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml")).Descendants("Word")

                               select new Word
                               {

                                   RusWord = word.Element("RusWord").Value.ToString(),
                                   EngWord = word.Element("EngWord").Value.ToString()

                               };
                foreach (var item in listWord)
                {
                    if (item.RusWord == _Word)
                    {
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine(item.EngWord);
                    }
                    else if (item.EngWord == _Word)
                    {
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine(item.RusWord);
                    }
                }

            }
            catch (Exception exp)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"\nСлово отсутствует в каталоге!");
            }

        }
        public static void DeleteWord(string _otherWord, string _language)
        {
            try
            {
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
                if (_language == "Rus")
                    xmlDoc.Element("Word").Elements("Word").Where(x => x.Element("RusWord").Value == _otherWord).FirstOrDefault().Remove();
                else if (_language == "Eng")
                    xmlDoc.Element("Word").Elements("Word").Where(x => x.Element("EngWord").Value == _otherWord).FirstOrDefault().Remove();
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"{_otherWord} было удалено");
            }
            catch (Exception exp)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"\nТакого слова нет в словаре или неправильно указан язык!!\nдля продолжения нажмите enter");
            }

        }
        public static void ChangeTranslation(string _otherWord, string _Translation, string _language)
        {
            try
            {
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
                if (_language == "Rus")
                    xmlDoc.Element("Word").Elements("Word").Where(x => x.Element("RusWord").Value == _otherWord).FirstOrDefault().SetElementValue("RusWord", _Translation);
                else if (_language == "Eng")
                    xmlDoc.Element("Word").Elements("Word").Where(x => x.Element("EngWord").Value == _otherWord).FirstOrDefault().SetElementValue("EngWord", _Translation);
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
            }
            catch (Exception exp)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"\nТакого слова нет в словаре или неправильно указан язык!!\nдля продолжения нажмите enter");
            }

        }
     }
}
