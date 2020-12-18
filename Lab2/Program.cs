using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        public enum Name
        {
            Jack, 
            Erik,
            Oliver,
            Robert,
            Anthony,
        }
        static string[] Number =
        {
            "35939193994",
            "7073024860458",
            "715090163068",
            "49425139994583",
            "950839949637",
        };
        static void Main(string[] args)
        {
            string[,] mass = new string[5, 2];
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (j == 0)
                        mass[i, j] = Convert.ToString((Name)i);
                    else
                    {
                        mass[i, j] = Number[i];
                    }
                }
            }
            Console.WriteLine($"Справочник");
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (j == 0)
                        Console.WriteLine($"Имя {mass[i, j]} ");
                    else
                        Console.WriteLine($"Номер телефона {mass[i, j]} ");

                }
                Console.WriteLine();
            }
        }
    }
}
