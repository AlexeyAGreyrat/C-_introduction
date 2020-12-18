using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = rnd.Next(10, 20);
            int[,] mass = new int[n, n];
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = rnd.Next(1, 10); 
                }
            }
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (i == j)
                        Console.Write(mass[i, j]);
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
