using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace Ponomarenko_Exam_Quiz
{
    public class Class_Task
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Name = "TaskBase";

        public Class_Task()
        {

        }
        public Class_Task(string _Id, string _Question, string _CorrectAnswer)

        {
            Id = _Id;
            Question = _Question;
            CorrectAnswer = _CorrectAnswer;



        }

        public void Task_entry()
        {
            try
            {
                var listTask = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml")).Descendants("Task")

                               select new Class_Task
                               {
                                   Id = word.Element("Id").Value.ToString(),
                                   Question = word.Element("Question").Value.ToString(),
                                   CorrectAnswer = word.Element("CorrectAnswer").Value.ToString()

                               };

                int flag = 0;
                foreach (var item in listTask)
                {

                    if (Id == item.Id)
                    {
                        flag = 1;
                    }

                }

                if (flag != 1)
                {
                    var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));

                    xmlDoc.Element("Task").Add(new XElement(("Task"),
                                     new XElement("Id", this.Id),
                                   new XElement("Question", this.Question),
                                  new XElement("CorrectAnswer", this.CorrectAnswer)));

                    xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
                }
                else
                {
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine($"Задание под номером {this.Id} уже существует и не может быть добавленно");
                    WriteLine();
                }

            }

            catch (Exception exp)

            {
                var xmlDoc = new XDocument(new XDeclaration("1.0", "utf=16", "yes"),
               new XElement("Task"));                                                           //создание каталога заданий

                xmlDoc.Root.Add(new XElement("Id", this.Id),
                               new XElement("Question", this.Question),
                               new XElement("CorrectAnswer", this.CorrectAnswer));
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));

            }

        }

        public void DeleteTask(string _Id)
        {
            try
            {
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));

                xmlDoc.Element("Task").Elements("Task").Where(x => x.Element("Id").Value == _Id).FirstOrDefault().Remove();
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"Задание с Id {_Id} было удалено");
                WriteLine();
            }
            catch (Exception exp)
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"\nЗадания с таким Id нет в каталоге и оно не может быть удалено" +
                    $"\nдля продолжения нажмите enter");
                WriteLine();
            }

        }
        public void ShowTask()
        {
            var listTask = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml")).Descendants("Task")

                           select new Class_Task
                           {
                               Id = word.Element("Id").Value.ToString(),
                               Question = word.Element("Question").Value.ToString(),
                               CorrectAnswer = word.Element("CorrectAnswer").Value.ToString()

                           };


            foreach (var item in listTask)
            {
                WriteLine(item);
                WriteLine();
            }
        }
        public void LoadTask(string _Id)
        {

            var listTask = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml")).Descendants("Task")

                           select new Class_Task
                           {
                               Id = word.Element("Id").Value.ToString(),
                               Question = word.Element("Question").Value.ToString(),
                               CorrectAnswer = word.Element("CorrectAnswer").Value.ToString()

                           };

            int flag = 0;

            foreach (var item in listTask)
            {
                if (item.Id == _Id)
                {
                    Id = item.Id;
                    Question = item.Question;
                    CorrectAnswer = item.CorrectAnswer;
                    flag = 1;
                }

            }


            if (flag != 1)
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"Задания с Id {_Id} еще нет в каталоге");
            }
            WriteLine();

        }

        public override string ToString()
        {
            ForegroundColor = ConsoleColor.Blue;
            return $"Номер вопроса {Id}\nВопрос:{Question} ";
        }
    }
}
