using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите строку");
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[(str.Length-1) - i]);
            }
            Console.WriteLine();
        }
    }
}
