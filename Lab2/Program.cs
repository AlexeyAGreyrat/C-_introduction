using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string Text = "startup.txt";
            File.AppendAllText(Text, $"Текущее время {Convert.ToString(String.Format("{0:HH:mm:ss }",DateTime.Now))}\n");
        }
    }
}
