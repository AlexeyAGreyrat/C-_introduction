using System;

namespace lesson1_lab1
{
    class Program
    {       
        static void Main()
        {
            Console.WriteLine("Введите имя пользвоателя");
            var name = Console.ReadLine();
            Console.WriteLine("Привет," + name + " сегодня " + DateTime.Now);            
        }
    }
}
