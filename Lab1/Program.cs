using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_4
{
    class Program
    {
        static string[] FirstName =
        {
            "David",
            "Paul",
            "Matthew",
            "Roland",
            "George",
        };
        static string[] LastName =
        {
            "Atkins",
            "Johns",
            "Allen",
            "Terry",
            "Dawson",
        };
        static string[] Patronymic =
        {
            "John",
            "Ronald",
            "Charles",
            "Brian",
            "Peter",
        };

        static void Main(string[] args)
        {
            Random rnd = new Random();
            string FIO = null;
            string firstName;
            string lastName;
            string patronymic;
            int k;
            Console.WriteLine("Сколько вывести ФИО");
            k = Convert.ToInt32(Console.ReadLine());
            while (k > 0)
            {                                
                firstName = FirstName[rnd.Next((FirstName.Length - FirstName.Length), FirstName.Length)];
                //(FirstName.Length - FirstName.Length) правильна ли такая запись чтобы не использовать магические числа? 
                lastName = LastName[rnd.Next(0, LastName.Length)];
                patronymic = Patronymic[rnd.Next(0, Patronymic.Length)];
                FIO = GetFullName(firstName, lastName, patronymic);
                Console.WriteLine($"{FIO}");
                k--;
            }
        }  
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return ($"{firstName} {lastName} {patronymic}");
        }
    }
}
