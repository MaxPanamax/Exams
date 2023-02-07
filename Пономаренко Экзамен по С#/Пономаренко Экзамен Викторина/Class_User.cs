using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Ponomarenko_Exam_Quiz//User ник-max , User пароль-1234
{
    public class Class_User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Class_User() { }
        public void HistoryWinShow()
        {
            try
            {
                Class_Task task = new Class_Task();
                task.Name = this.Login + "Win";
                task.ShowTask();
            }
            catch (Exception exp)
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("У вас еще нет побед. \nДля продолжения нажмите enter");
            }
        }
        public void UserLoad(string _Login, string _Password)
        {
            var listUser = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, "User.xml")).Descendants("User")

                           select new Class_User
                           {
                               Login = word.Element("Login").Value.ToString(),
                               Password = word.Element("Password").Value.ToString()
                           };
            int flag = 0;
            foreach (var item in listUser)
            {
                if (item.Login == _Login && item.Password == _Password)
                {
                    Login = _Login;
                    Password = _Password;
                    flag = 1;
                }
            }
            if (flag != 1)
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("Неправильный логин или пароль!");
                WriteLine();
            }
            else
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"Профиль {Login} загружен");
                WriteLine();
            }
        }
        public void User_entry(string _Login, string _Password)
        {
            Login = _Login;
            Password = _Password;
            try
            {
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "User.xml"));

                xmlDoc.Element("User").Add(new XElement(("User"),
                                 new XElement("Login", this.Login),
                               new XElement("Password", this.Password)));

                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "User.xml"));
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"Пользователь: {this.Login} Пароль: {this.Password} \nБыл добавлен в каталог");
                WriteLine();
            }
            catch (Exception exp)
            {
                var xmlDoc = new XDocument(new XDeclaration("1.0", "utf=16", "yes"),
                new XElement("User"));
                xmlDoc.Root.Add(new XElement("Login", this.Login),
                               new XElement("Password", this.Password));
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "User.xml"));
            }
        }
        public void HistoryWinEntry(Class_Task other)
        {
            other.Name = this.Login + "Win";
            other.Task_entry();
        }
        public void Game()
        {
            Class_Task task = new Class_Task();
            task.ShowTask();
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("Выберете заданиe, введите его номер");
            ForegroundColor = ConsoleColor.Green;
            string Id = ReadLine();
            try
            {
                task.LoadTask(Id);
                string letter;
                Clear();
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("Используйте кириллицу-нижний регистр");
                WriteLine($"Задание:");
                WriteLine(task.Question);
                WriteLine();
                WriteLine("Введите ответ: ");
                WriteLine();
                letter = ReadLine();
                Clear();
                if (!letter.Equals(task.CorrectAnswer))
                {
                    SoundPlayer sp2 = new SoundPlayer("GameOver.wav");
                    sp2.Play();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("!!!Вы проиграли!!!");
                }
                else
                {
                    SoundPlayer sp3 = new SoundPlayer("Prize.wav");
                    sp3.Play();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("!!!ВЫ ПОБЕДИЛИ!!!");
                }
            }
            catch (Exception exp)
            {
                WriteLine(exp);
            }
        }
        public override string ToString()
        {
            ForegroundColor = ConsoleColor.Blue;
            return $"Логин:{Login} \nПароль:{Password} ";
        }
    }
}
