using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Dictionary
{
    class Program: Methods
    {
        static void Main(string[] args)
        {
            int caseSwitch = 0;
            string Word;
            string Word2;
            string language;
            while (caseSwitch != 6)
            {
                Clear();
                WriteLine();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine($"\t\t\t\t\t\tМЕНЮ \n\n\t\t\t\t1 Перевод \n\n\t\t\t\t2 Удаление из словаря \n\n\t\t\t\t3 Добавление в словарь " +
                    $"\n\n\t\t\t\t4 Изменение уже существующего перевода \n\n\t\t\t\t5 Список слов \n\n\t\t\t\t6 Выход");
                WriteLine();
                try
                {
                    caseSwitch = Convert.ToInt32(ReadLine());
                }
                catch (Exception exp)
                {
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine($"{exp}\nДля взаимодействия с меню нажмите клавишу 1, 2, 3, 4 или 5" +
                        $" затем enter\nНажмите enter для продолжения");
                    ReadKey();
                }
                ResetColor();//возврат цвета опо умолчаниию
                switch (caseSwitch)
                {
                    case 1:
                        ForegroundColor = ConsoleColor.Blue;//цвет текста
                        Write("Введите слово: ");
                        ForegroundColor = ConsoleColor.Green;
                        Word = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        Write("Перевод: ");
                        Translation(Word);
                        ReadKey();
                        break;

                    case 2:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите слово: ");
                        ForegroundColor = ConsoleColor.Green;
                        Word = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Выберете язык в формате Rus или Eng: ");
                        language = ReadLine();
                        DeleteWord(Word, language);
                        ReadKey();
                        break;

                    case 3:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите слово(Rus): ");
                        ForegroundColor = ConsoleColor.Green;
                        Word = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите перевод(Eng): ");
                        ForegroundColor = ConsoleColor.Green;
                        language = ReadLine();
                        Word NewWord = new Word(Word, language);
                        NewWord.Word_entry();
                        ReadKey();
                        break;

                    case 4:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите слово: ");
                        ForegroundColor = ConsoleColor.Green;
                        Word = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Выберете язык в формате Rus или Eng: ");
                        ForegroundColor = ConsoleColor.Green;
                        language = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите новый перевод: ");
                        ForegroundColor = ConsoleColor.Green;
                        Word2 = ReadLine();
                        ChangeTranslation(Word, Word2, language);
                        ReadKey();
                        break;

                    case 5:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Слова в словаре: \n");
                        All_words();
                        ReadKey();
                        break;

                    default:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Bye");
                        break;

                }

            }
        }
    }
}

