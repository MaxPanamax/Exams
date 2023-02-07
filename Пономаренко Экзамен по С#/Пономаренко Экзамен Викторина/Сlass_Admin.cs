using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Ponomarenko_Exam_Quiz//Admin ник-Panama ,Admin пароль-1978 
{
    class Сlass_Admin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Сlass_Admin()
        {

        }
        public void AdminLoad(string _Login, string _Password)

        {
            Login = _Login;
            Password = _Password;

            var listAdmin = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Admin.xml")).Descendants("Admin")

                            select new Сlass_Admin
                            {

                                Login = word.Element("Login").Value.ToString(),
                                Password = word.Element("Password").Value.ToString()

                            };

            int flag = 0;
            foreach (var item in listAdmin)
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
            }
            else
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"Профиль {Login} загружен");
                WriteLine();
            }
        }

        public void AdminStart(string _Login, string _Password)
        {
            Login = _Login;                                                                   //создание каталога администраторов
            Password = _Password;
            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf=16", "yes"),
                new XElement("Admin"));
            xmlDoc.Root.Add(new XElement("Login", this.Login),
                           new XElement("Password", this.Password));
            xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "Admin.xml"));
            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"Профиль {Login} cохранен");
        }
        public void AdminTaskEntry(string _Id, string _Question, string _CorrectAnswer)
        {
            Class_Task new_task = new Class_Task(_Id, _Question, _CorrectAnswer);
            new_task.Task_entry();
        }

        public void AdminDeleteTask(string _Id)
        {
            Class_Task new_task = new Class_Task();
            new_task.DeleteTask(_Id);
        }
        public void AdminShowTask()
        {
            Class_Task new_task = new Class_Task();
            new_task.ShowTask();
        }
        public override string ToString()
        {
            ForegroundColor = ConsoleColor.Blue;
            return $"Логин:{Login} \nПароль:{Password} ";
        }

    }
}
