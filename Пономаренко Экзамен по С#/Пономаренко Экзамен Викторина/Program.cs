using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Ponomarenko_Exam_Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Сlass_Admin admin = new Сlass_Admin();
            Class_User user = new Class_User();
            string _Login = null;
            string _Password = null;
            int caseSwitch = 0;
            while (caseSwitch != 6)
            {
                Clear();
                WriteLine();
                SoundPlayer sp4 = new SoundPlayer("Muzyka 1.wav");
                sp4.Play();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine($"\n\n\t\t\t\tМеню \n\n\t\t\t\t1 Администратор-регистрация" +
                    $"  \n\n\t\t\t\t2 Администратор-войти \n\n\t\t\t\t3 Пользователь-регистрация " +
                    $"\n\n\t\t\t\t4 Пользователь-войти\n\n\t\t\t\t" +
                    $"5 Инструкция использования\n\n\t\t\t\t6 Для продолжения или выхода если вы авторизован ");
                WriteLine();
                try
                {
                    ForegroundColor = ConsoleColor.Blue;
                    caseSwitch = Convert.ToInt32(ReadLine());

                }
                catch (Exception exp)
                {
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine($"\nДля взаимодействия с меню нажмите клавишу 1, 2, 3, 4 или 5 затем enter\nНажмите enter для продолжения");
                    ReadKey();
                }

                switch (caseSwitch)
                {
                    case 1:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите логин");
                        ForegroundColor = ConsoleColor.Green;
                        _Login = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите пароль");
                        ForegroundColor = ConsoleColor.Green;
                        _Password = ReadLine();
                        admin.AdminStart(_Login, _Password);
                        break;
                    case 2:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите логин");
                        ForegroundColor = ConsoleColor.Green;
                        _Login = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите пароль");
                        ForegroundColor = ConsoleColor.Green;
                        _Password = ReadLine();
                        admin.AdminLoad(_Login, _Password);
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Нажмите enter");
                        ReadKey();
                        break;
                    case 3:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите логин");
                        ForegroundColor = ConsoleColor.Green;
                        _Login = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите пароль");
                        ForegroundColor = ConsoleColor.Green;
                        _Password = ReadLine();
                        user.User_entry(_Login, _Password);
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Нажмите enter");
                        ReadKey();
                        break;
                    case 4:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите логин");
                        ForegroundColor = ConsoleColor.Green;
                        _Login = ReadLine();
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Введите пароль");
                        ForegroundColor = ConsoleColor.Green;
                        _Password = ReadLine();
                        user.UserLoad(_Login, _Password);
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Нажмите enter");
                        ReadKey();
                        break;
                    case 5:
                        SoundPlayer sp2 = new SoundPlayer("muzyka 2.wav");
                        sp2.Play();
                        ForegroundColor = ConsoleColor.Magenta;
                        WriteLine("\tПравила пользования: \n\t1 Необходимо зарегистрироватся как ползователь" +
                            " если вы хоите проверить ваши знания\n\t2 Необходимо зарегистрироватся " +
                            "как администратор если вы хотите добавить задания уили убрать\n\t3 Пользователю " +
                            "необходимо выбрать вопрос и ответить на него"+
                            "\n\t5 Сушествует рейтинг\n\tПриятного пользования");
                        WriteLine("Нажмите enter");
                        ReadKey();
                        break;
                    default:
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine("Bye");
                        break;
                }
            }
            if (admin.Login != null)
            {
                int caseSwitchAdmin = 0;
                while (caseSwitchAdmin != 4)
                {
                    Clear();
                    WriteLine();
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine($"\n\n\t\t\t\t1 Добавить задание в каталог" +
                        $"\n\n\t\t\t\t2 Удалить задание из каталога" +
                        $"\n\n\t\t\t\t3 Просмотреть каталог вопросов\n\n\t\t\t\t4 Выход");
                    WriteLine();
                    try
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        caseSwitchAdmin = Convert.ToInt32(ReadLine());
                    }
                    catch (Exception exp)
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine($"\nДля взаимодействия с меню нажмите клавишу 1, 2, 3, 4 затем enter\nНажмите enter для продолжения");
                        ReadKey();
                    }

                    switch (caseSwitchAdmin)
                    {
                        case 1:
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Введите Id нового задания");
                            ForegroundColor = ConsoleColor.Green;
                            string _Id = ReadLine();
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Введите условие нового задания");
                            ForegroundColor = ConsoleColor.Green;
                            string _Question = ReadLine();
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Введите ожидаемый ответ для нового задания");
                            ForegroundColor = ConsoleColor.Green;
                            string _CorrectAnswer = ReadLine();
                            admin.AdminTaskEntry(_Id, _Question, _CorrectAnswer);
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Нажмите enter");
                            ReadKey();
                            break;
                        case 2:
                            admin.AdminShowTask();
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Введите Id задания, которое хотите удалить");
                            ForegroundColor = ConsoleColor.Green;
                            _Id = ReadLine();
                            admin.AdminDeleteTask(_Id);
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Нажмите enter");
                            ReadKey();
                            break;
                        case 3:
                            admin.AdminShowTask();
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Нажмите enter");
                            ReadKey();
                            break;
                        default:
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Bye");
                            break;
                    }
                }
            }
            if (user.Login != null)
            {
                int caseSwitchUser = 0;
                while (caseSwitchUser != 3)
                {
                    SoundPlayer sp4 = new SoundPlayer("Muzyka 1.wav");
                    sp4.Play();
                    Clear();
                    WriteLine();
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine($"введите: \n1 Для старта игры  \n2 Для просмотра истории побед \n3 Выход  ");
                    WriteLine();
                    try
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        caseSwitchUser = Convert.ToInt32(ReadLine());
                    }
                    catch (Exception exp)
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine($"\nДля взаимодействия с меню нажмите клавишу 1, 2, 3 затем enter\nНажмите enter для продолжения");
                        ReadKey();
                    }
                    switch (caseSwitchUser)
                    {
                        case 1:
                            user.Game();
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Нажмите enter");
                            ReadKey();
                            break;
                        case 2:
                            user.HistoryWinShow();
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine("Нажмите enter");
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
}

