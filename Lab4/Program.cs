using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string workDir = @"C:\C#";
            File.Delete("text.txt");
            File.Delete("text1.txt");
            Console.WriteLine($"1 - Вывести с рекурсией");
            Console.WriteLine($"2 - Вывести  без рекурсии");
            int chek = int.Parse(Console.ReadLine());
            if (chek == 1)            
                Rec(workDir, "");            
            else            
                NoRec(workDir);            
        }

        static void NoRec(string workDir)
        {
            string[] entries = Directory.GetDirectories(workDir, "*", SearchOption.TopDirectoryOnly);
            foreach (string dirName in entries)
            {
                    File.AppendAllText("text1.txt", $" {dirName}\n ");
                    Console.WriteLine(dirName);
                foreach (string dir in Directory.GetDirectories(dirName, "*", SearchOption.AllDirectories))
                {
                    File.AppendAllText("text1.txt", $" {dir}\n ");
                    Console.WriteLine($" {dir}");
                    if (Directory.GetFiles(dir, "*.*", SearchOption.TopDirectoryOnly).Length > 0)
                    {
                        foreach (string fileName in Directory.GetFiles(dir, "*.*", SearchOption.TopDirectoryOnly))
                        {
                            File.AppendAllText("text1.txt", $" {fileName}\n ");
                            Console.WriteLine($" {fileName} ");
                        }
                    }
                }
                

            }            
        }         
        static void Rec(string workDir,string s)
        {
            string str = s;
            string[] entries = Directory.GetDirectories(workDir, "*", SearchOption.TopDirectoryOnly);
            string[] allFiles = Directory.GetFiles(workDir, ".", SearchOption.TopDirectoryOnly);
            if(allFiles.Length != 0)
            {
                for (int i = 0; i < allFiles.Length; i++)
                {
                    Console.WriteLine(s + "└── " + allFiles[i]);
                    File.AppendAllText("text.txt", s + allFiles[i] + "\n");
                }
            }
            for (int i = 0; i < entries.Length; i++)
            {
                if (s == "")
                {
                    Console.WriteLine(s + entries[i]);                    
                    File.AppendAllText("text.txt", s + entries[i]+"\n");                    
                }
                else
                {                    
                        Console.WriteLine(s + "└── " + entries[i]);
                        File.AppendAllText("text.txt", s + "└── " + entries[i] + "\n");                                  
                }            
                str = str +" ";
                Rec(entries[i],str);                
            }            
        }
    }
}
