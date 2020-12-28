using System;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            Show(processes);
            bool chekMenu = true;
            while (chekMenu == true)
            {
                try
                {
                    Console.WriteLine("1 - Завершить процесс через имя процесса");
                    Console.WriteLine("2 - Завершить процесс через ID процесса");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Введите имя процесса");
                            nameProcesses(Console.ReadLine(), ref processes);
                            chekMenu = false;
                            break;
                        case 2:
                            Console.WriteLine("Введите ID процесса");
                            idProcesses(Console.ReadLine(), ref processes);
                            chekMenu = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка Введите число 1 или 2 ");
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка Введите число 1 или 2 ");
                }
            }
        }
        static void idProcesses(string s, ref Process[] processes)
        {
                foreach (var proces in processes)
                {
                    if (s == Convert.ToString(proces.Id))
                        proces.Kill();                                     
                }
                processes = Process.GetProcesses();
                Show(processes);        
        }
        static void nameProcesses(string s, ref Process[] processes)
        {
            foreach (var proces in processes)
            {
                if (s == Convert.ToString(proces.ProcessName))
                    proces.Kill();
            }
            processes = Process.GetProcesses();
            Show(processes);
        }
            static void Show(Process[] processes)
        {
            foreach (var proces in processes)
            {
                Console.WriteLine($"Имя процесса: {proces.ProcessName} - ID процесса: {proces.Id}");
            }
        }
    }
}
