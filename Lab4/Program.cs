using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int FN;
            int[] mass;
            int n;
            Console.WriteLine("1 - Вывести номер числа \n2 - Вывести Последовательность чисел");
            int tmp = int.Parse(Console.ReadLine());
            bool chek = true;
            while (chek == true)
            {
                switch (tmp)
                {
                    case 1:
                        Console.WriteLine("Введите Номер числа Фибоначчи");
                        n = int.Parse(Console.ReadLine());
                        FN = Fib(n);
                        Console.WriteLine($"Число Фибоначчи под номером {n} : {FN}");
                        chek = false;
                        break;
                    case 2:
                        Console.WriteLine("Введите до какого числа вывести последовательность(от 0 до n(включительно))");
                        n = int.Parse(Console.ReadLine());
                        mass = new int[Math.Abs(n) + 1];
                        mass = FibO(n);
                        if (n > 0)
                        {
                            int i = 0;
                            while (n >= 0)
                            {
                                Console.Write($" {mass[i++]} ");
                                n--;
                            }
                            chek = false;
                        }
                        else
                        {
                            n = Math.Abs(n);
                            int i = 0;
                            while (n >= 0)
                            {
                                mass[i] = i % 2 == 0 ? -mass[i] : mass[i];
                                Console.Write($" {mass[i++]}");
                                n--;
                            }
                            chek = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Ошибка. Введите Значение 1 или 2");
                        Console.WriteLine("1 - Вывести номер числа \n2 - Вывести Последовательность чисел");
                        tmp = int.Parse(Console.ReadLine());
                        break;
                }
            }

        }
        static int FibRec(int fn1, int fn2, int n)
        {
            return n == 0 ? fn1 : FibRec(fn2, fn1 + fn2, n - 1);
        }
        static int Fib(int n) 
        {
            int f0 = 0;
            int f1 = 1;
            if(n>0)
            return FibRec(f0, f1, n);
            else
            {
                n = Math.Abs(n);
                if (n % 2 != 0)
                    return FibRec(f0, f1, n);
                else
                    return -FibRec(f0, f1, n);
            }
        }    

        static int[] FibO(int n)
        {
            n = Math.Abs(n);
            int[] mass = new int[n+1];
            int f0 = 0;
            int f1 = 1;         
            return FibOrder(f0, f1, n, mass);

        }
        static int[] FibOrder(int fn1, int fn2, int n, int[] mass)
        {
            if (n == 0)
            {
                mass[n] = fn1;
                int chek = mass.Length;
                int[] massd = new int[mass.Length];
                foreach (var i in mass)
                massd[--chek] = i;                 
                return massd;
            }
            else
            {                
                mass[n] = fn1;
                return FibOrder(fn2, fn1 + fn2, n - 1,mass);                   
            }
        }
    }
}