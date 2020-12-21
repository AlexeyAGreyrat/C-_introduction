using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        public enum Month
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сетнябрь,
            Октябрь,
            Ноябрь,
            Декабрь,
        }
        public enum Season
        {
            Winter,
            Spring,
            Summer,
            Autumn,
        }
        static void Main(string[] args)
        {
            Season year;
            int month;
            while (true)
            {
                Console.WriteLine("Введите номер месяца");
                month = int.Parse(Console.ReadLine());
                if (1 <= month & month <= 12)
                    break;
                else
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
            }
            year = Year(month);
            Console.WriteLine($"Месяц {month}: {(Month)month} \nВремя года: {season(year)}");
        }
        static string season(Season year)
        {
            switch(year)
            {
                case Season.Winter:
                    return "Зима";
                case Season.Autumn:
                    return "Осень";
                case Season.Spring:
                    return "Весна";
                case Season.Summer:
                    return "Лето";
            }
            return null;
        }
        static Season Year(int month)
        {
            Season season = Season.Autumn;
            switch (month)
            {
                case 1:
                case 2:
                case 12:
                    season = Season.Winter;
                    break;
                case 3:
                case 4:
                case 5:
                    season = Season.Spring;
                    break;
                case 6:
                case 7:
                case 8:
                    season = Season.Summer;
                    break;
                case 9:
                case 10:
                case 11:
                    season = Season.Autumn;
                    break;
            }            
            return season;
        }
    }
}
