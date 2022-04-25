using System;

namespace buterfly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "информация о бабочках";

            Console.WriteLine("Информация о бабочках");
            try
            {
                View.MyConsole myConsole = new View.MyConsole("buterfly.bin");//создание файла для информации 
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("программа закончила свою работу ");
            
            Console.ReadLine(); 
        }
    }
}