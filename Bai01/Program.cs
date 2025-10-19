using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int month, year;
            while (true)
            {
                Console.Write("Nhập tháng: ");
                month = int.Parse(Console.ReadLine());
                Console.Write("Nhập năm: ");
                year = int.Parse(Console.ReadLine());
                if (month < 1 || month > 12 || year < 0)
                {
                    Console.WriteLine("Tháng hoặc năm không hợp lệ, vui lòng nhập lại!");
                }
                else
                    break;
            }
            // Lấy ngày đầu tiên của tháng
            DateTime first_day_of_a_month = new DateTime(year, month, 1);
            // Lấy thứ của ngày đầu tiên trong tháng
            var first_day_of_week_of_a_month = first_day_of_a_month.DayOfWeek;

            // Lấy số ngày trong tháng
            int days_in_month = DateTime.DaysInMonth(year, month);
            // In lịch
            Console.WriteLine("\nMonth:{0}/{1}",month.ToString().PadLeft(2,'0'),year);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("| Sun | Mon | Tue | Wed | Thu | Fri | Sat |");
            Console.WriteLine("-------------------------------------------");
            for (int i = 0; i < (int)first_day_of_week_of_a_month; i++)
            {
                Console.Write("|     ");
            }
            for (int day = 1; day <= days_in_month; day++)
            {
                Console.Write("|  {0} ", day.ToString().PadRight(2));
                if (DayOfWeek.Saturday == (new DateTime(year, month, day).DayOfWeek))
                {
                    Console.WriteLine("|");
                    Console.WriteLine("-------------------------------------------");
                }
            }
            // In các ô trống còn lại trong tuần cuối cùng của tháng
            int last_day_of_week_of_a_month = (int)(new DateTime(year, month, days_in_month).DayOfWeek);
            
            for (int i = last_day_of_week_of_a_month + 1; i <= 6; i++)
            {
                Console.Write("|     ");
                if (i == 6)
                {
                    Console.WriteLine("|");
                    Console.WriteLine("-------------------------------------------");
                }
            }
        }
    }
}
