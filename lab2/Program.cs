using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        public enum Month
        {
            Январь  = 1,
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
        static void Main(string[] args)
        {
            //Запросить у пользователя порядковый номер текущего месяца и вывести его название.
            #region Задание 2
            Console.WriteLine("Введите порядковый номер текущего месяца");
            int month = Convert.ToInt32(Console.ReadLine());
            if(month <= 12 && month > 0 )
            {
                Month month1 = (Month)month;
                Console.WriteLine(month1);
            }
            else            
                Console.WriteLine("Ошибка порядковый номер месеца не существует");
            #endregion
        }
    }
}
