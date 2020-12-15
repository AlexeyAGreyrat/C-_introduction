using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Определить, является ли введённое пользователем число чётным.
            #region Задание 3
            Console.WriteLine("Введите число");
            int num = Convert.ToInt32(Console.ReadLine());
            if ((num % 2) == 0)
                Console.WriteLine("Число четное");
            else
                Console.WriteLine("Число не четное");
            #endregion
        }
    }
}
