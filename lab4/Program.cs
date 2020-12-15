using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab4
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
    class Program
    {
        
        static void Main(string[] args)
        {
            //(*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
            #region Задание 4
            Console.WriteLine("Ввдите  максимальную температуру за сутки");
            int temMin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ввдите минимальную температуру за сутки");
            int temMax = Convert.ToInt32(Console.ReadLine());            
            Console.WriteLine("Введите порядковый номер текущего месяца");
            int month = Convert.ToInt32(Console.ReadLine());
            float temS = (float)(temMax + temMin) / 2;
            if (month <= 12 && month > 0)
            {
                Month month1 = (Month)month;
                if (temS > 0)
                {
                    switch (month)
                    {
                        case 1:
                        case 2:
                            Console.WriteLine($"Месяц - {month1} \nСредняя температура {temS}");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Дождливая зима");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case 12:
                            Console.WriteLine($"Месяц - {month1} \nСредняя температура {temS}");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Дождливая зима");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        default:
                            Console.WriteLine($"Месяц - {month1} \nСредняя температура {temS}");
                            break;
                    }
                }
                else
                    Console.WriteLine($"Месяц - {month1} \nСредняя температура {temS}");
            }
            else
            {
                Console.WriteLine("Ошибка порядковый номер месеца не существует");
                return;
            }
            #endregion
        }
    }
}
