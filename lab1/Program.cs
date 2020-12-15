using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
            #region Задание 1
            Console.WriteLine("Ввдите  максимальную температуру за сутки");
            int temMax = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ввдите минимальную температуру за сутки");
            int temMin = Convert.ToInt32(Console.ReadLine());
            float temS = (float)(temMax + temMin) / 2;
            Console.WriteLine($"Средняя температура сегодня {temS}");
            #endregion 
        }
    }
}
