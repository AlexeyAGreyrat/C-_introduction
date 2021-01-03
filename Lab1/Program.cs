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
            //lesson 8
            string strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                Console.WriteLine($"Введите имя");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Console.WriteLine($"Введите возраст");
                Properties.Settings.Default.UserAge = Console.ReadLine();
                Console.WriteLine($"Введите род деятельности");
                Properties.Settings.Default.UserType = Console.ReadLine();
                Properties.Settings.Default.Save();
                Console.WriteLine($"Версия программы :{strVersion}");
            }
            else
            {
                Console.WriteLine($"{Properties.Settings.Default.UserName} {Properties.Settings.Default.UserAge} {Properties.Settings.Default.UserType}");                
                Console.WriteLine($"Версия программы :{strVersion}");
                Properties.Settings.Default.Reset();
            }
            

        }
    }
}
