using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDo toDoTask;
            int n=0;
            string json = null;
            bool chekMenu = true;
            bool chekEnter = true;
            bool chekSet;
            string[] task=null;
            bool[] purpose=null;
            string[] copyTask=null;
            bool[] copyPurpose=null;
            //
            while (chekMenu == true)
            {
                Console.WriteLine($"1 - Ввести список задач");
                Console.WriteLine($"2 - Загрузить список задач");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        chekMenu = false;
                        while (chekEnter == true)
                        {
                            chekSet = true;
                            Console.WriteLine($"Введите задачу");
                            string s = Console.ReadLine();
                            n++;
                            bool chek = false;
                            task = new string[n];
                            purpose = new bool[n];
                            if (copyTask != null)
                            {
                                for (int i = 0; i < copyTask.Length; i++)
                                {
                                    task[i] = copyTask[i];
                                    purpose[i] = copyPurpose[i];
                                }
                                for (int i = copyTask.Length; i < task.Length; i++)
                                {
                                    task[i] = s;
                                    purpose[i] = chek;
                                }
                            }
                            else
                            {
                                for (int i = 0; i < task.Length; i++)
                                {
                                    task[i] = s;
                                    purpose[i] = chek;
                                }
                            }
                            while (chekSet == true)
                            {
                                Console.WriteLine($"1-Продолжить ввод задач");
                                Console.WriteLine($"2-Закончить ввод задач");
                                switch (int.Parse(Console.ReadLine()))
                                {
                                    case 1:
                                        copyTask = task;
                                        copyPurpose = purpose;
                                        chekSet = false;
                                        break;
                                    case 2:
                                        chekSet = false;
                                        chekEnter = false;
                                        break;
                                    default:
                                        Console.WriteLine($"Ошибка повторите Ввод");
                                        break;
                                }
                            }
                        }
                        Console.WriteLine($"Cписок задач");
                        toDoTask = new ToDo(task, purpose);
                        Print(toDoTask);
                        toDoTask = change(toDoTask);
                        Save(toDoTask);                        
                        break;
                    case 2:
                        chekMenu = false;
                        Console.WriteLine($"1-Загрузить задачи через json");
                        Console.WriteLine($"2-Загрузить задачи через xml");
                        Console.WriteLine($"3-Загрузить задачи через bin");
                        chekSet = true;
                        while (chekSet == true)
                        {
                            switch (int.Parse(Console.ReadLine()))
                            {
                                case 1:
                                    json = File.ReadAllText("tasks.json");
                                    toDoTask = JsonSerializer.Deserialize<ToDo>(json);
                                    Console.WriteLine($"Загрузка успешно");
                                    Console.WriteLine($"Cписок задач");
                                    Print(toDoTask);
                                    toDoTask = change(toDoTask);
                                    Save(toDoTask);
                                    chekSet = false;
                                    break;
                                case 2:
                                    string xmlText = File.ReadAllText("tasks.xml");
                                    StringReader stringReader = new StringReader(xmlText);
                                    XmlSerializer serializer = new XmlSerializer(typeof(ToDo));
                                    toDoTask = (ToDo)serializer.Deserialize(stringReader);
                                    Console.WriteLine($"Загрузка успешно");
                                    Console.WriteLine($"Cписок задач");
                                    Print(toDoTask);
                                    toDoTask = change(toDoTask);
                                    Save(toDoTask);
                                    chekSet = false;
                                    break;
                                case 3:
                                    BinaryFormatter formatter = new BinaryFormatter();
                                    FileStream listBin = new FileStream("tasks.bin", FileMode.Open);
                                    toDoTask = (ToDo)formatter.Deserialize(listBin);
                                    listBin.Close();
                                    Console.WriteLine($"Загрузка успешно");
                                    Console.WriteLine($"Cписок задач");
                                    Print(toDoTask);
                                    toDoTask = change(toDoTask);
                                    Save(toDoTask);
                                    chekSet = false;
                                    break;
                                default:
                                    Console.WriteLine($"Ошибка повторите Ввод");
                                    break;
                            }
                        }                        
                        break;
                    default:
                        Console.WriteLine($"Ошибка повторите Ввод");
                        break;

                }
            }
            //
        }
        static ToDo change(ToDo to)
        {
            Console.WriteLine($"1 - Отметить выполненые задачи?");
            Console.WriteLine($"2 - Выход");
            bool chekSet = true;
            bool chekEnter = true;
            while (chekEnter == true)
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        while (chekSet == true)
                        {
                            Console.WriteLine($"№ Задачи");
                            Print(to);
                            int tmp = int.Parse(Console.ReadLine()) - 1;
                            if (tmp >= 0 & tmp < to.Title.Length)
                            {
                                if (to.IsDone[tmp] != true)
                                    to.IsDone[tmp] = true;
                                else
                                    to.IsDone[tmp] = false;
                            }
                            Print(to);
                            Console.WriteLine($"1 - Продолжить менять");
                            Console.WriteLine($"2 - Выход");
                            if (int.Parse(Console.ReadLine()) == 2)
                            {
                                chekSet = false;
                                chekEnter = false;
                            }
                        }
                        break;
                    case 2:
                        chekEnter = false;
                        break;
                    default:
                        Console.WriteLine($"Ошибка повторите Ввод");
                        break;
                }
            }
            return to;
        }
        static void Save(ToDo to)
        {
            Console.WriteLine($"Сохранить список задач");
            Console.WriteLine($"1-Сохранить задачи через json");
            Console.WriteLine($"2-Сохранить задачи через xml");
            Console.WriteLine($"3-Сохранить задачи через bin");
            bool chekSet = true;
            while (chekSet == true)
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                       string json = JsonSerializer.Serialize(to);
                        File.WriteAllText("tasks.json", json);
                        chekSet = false;
                        Console.WriteLine($"Сохранено успешно");
                        break;
                    case 2:
                        StringWriter stringWriter = new StringWriter();
                        XmlSerializer serializer = new XmlSerializer(typeof(ToDo));
                        serializer.Serialize(stringWriter, to);
                        string xml = stringWriter.ToString();
                        File.WriteAllText("tasks.xml", xml);
                        chekSet = false;
                        Console.WriteLine($"Сохранено успешно");
                        break;
                    case 3:
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(new FileStream("tasks.bin",FileMode.OpenOrCreate), to);
                        chekSet = false;
                        Console.WriteLine($"Сохранено успешно");
                        break;
                    default:
                        Console.WriteLine($"Ошибка повторите Ввод");
                        break;
                }
            }
        }
        static void Print(ToDo to)
        {
            for (int i = 0; i < to.Title.Length; i++)
            {
                Console.Write($"{i + 1} - {to.Title[i]} ");
                if (to.IsDone[i] == true)
                    Console.WriteLine(" <<[X]>> ");
                else
                    Console.WriteLine(" <<[O]>> ");
            }
        }
    }
}
