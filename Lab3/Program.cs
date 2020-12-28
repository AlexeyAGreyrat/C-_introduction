using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] s = null;
            while (true)
            {
                bool Schek = true;                
                Console.WriteLine("Введите последовательность");
                string str = Console.ReadLine();                
                s = new byte[str.Split(' ').Length];
                for (int i = 0; i < str.Split(' ').Length; i++)
                {
                    if (Convert.ToInt32(str.Split(' ')[i]) < 255 & Convert.ToInt32(str.Split(' ')[i]) > 0)
                        s[i] = Convert.ToByte(str.Split(' ')[i]);
                    else
                    {
                        Console.WriteLine($"Ошибка Введите Числа от 0 до 255");
                        Schek = false;
                        break;
                    }
                }                
                if(Schek == true)
                {
                    break;
                }
            }
            File.WriteAllBytes("bytes.bin", s);           
        }
    }
}
