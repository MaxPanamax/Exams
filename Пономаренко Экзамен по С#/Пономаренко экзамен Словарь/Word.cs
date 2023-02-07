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
    public class Word
    {
        public string RusWord { get; set; }
        public string EngWord { get; set; }

        public Word() { }
        public Word(string _RusWord, string _EngWord)

        {
            RusWord = _RusWord;
            EngWord = _EngWord;

        }
        public void Word_entry()
        {
            try
            {
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));

                xmlDoc.Element("Word").Add(new XElement(("Word"),
                               new XElement("RusWord", RusWord),
                          new XElement("EngWord", EngWord)));
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"{RusWord}=={EngWord} Было добавлено в словарь");
            }
            catch (Exception exс)
            {
                var xmlDoc = new XDocument(new XDeclaration("1.0", "utf=16", "yes"),
                    new XElement("Word"));
                xmlDoc.Root.Add(new XElement("RusWord", RusWord),
                               new XElement("EngWord", EngWord));
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"{RusWord}=={EngWord} Было добавлено в словарь");
            }
        }


    }
}
