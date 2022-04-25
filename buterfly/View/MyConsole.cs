using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace buterfly.View
{
    internal class MyConsole
    {

        private Admin.AdminFly but;

        public MyConsole(string path)
        {
            try
            {
                but = new Admin.AdminFly(path);
                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Start()
        {
            PrintMenu();
            while (true)
            {
                try
                {
                    switch (ConsoleS("Введите команду...").ToLower())
                    {
                        case "commands": PrintMenu(); break;//вывод команд 
                        case "list": GetContent(); break;//получение сохраненной информации в файле 
                        case "add": AddContent(); break;//добавление информации о бабочках 
                        case "exit": Environment.Exit(0); break;//выход из консоли 
                        default:
                            Console.WriteLine("неверная команда"); break;
                    }
                }
                catch (Exception ex) // ловим все  ошибки
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddContent()
        {
            string name = ConsoleS("введите название бабочки");
            string view = ConsoleS("укажите вид");
            string live = ConsoleS("укажите продолжительность жизни");
            string definition = ConsoleS("введите краткое описание");
            string location = ConsoleS("укажите место обитания");
            but.Add(name, view, live, definition, location);
            Console.WriteLine("информаця о бабочках добавлена");
            GetContent();
        }

        private void GetContent()
        {
            if (but.Buts.Count == 0)
            {
                Console.WriteLine("иноформация о бабочках отсутстувует");
                return;
            }

            foreach (var item in but.Buts)
            {
                Console.WriteLine(item);
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("commands -список команд");
            Console.WriteLine("exit - Выход");
            Console.WriteLine("list -список информации о бабочках");
            Console.WriteLine("add -добавить информацию о бабочках");
        }

        private string ConsoleS(string v)
        {
            Console.WriteLine(v);
            var s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("некорректный ввод");
                return ConsoleS(v);
            }
            return s.TrimStart().TrimEnd();
        }
    }
}