using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Nhập tháng: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Nhập năm: ");
        int year = int.Parse(Console.ReadLine());

        PrintCalendar(month, year);
    }

    static void PrintCalendar(int month, int year)
    {
        Console.WriteLine($"\nMonth: {month:D2}/{year}");
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        DateTime firstDay = new DateTime(year, month, 1);
        int startDay = (int)firstDay.DayOfWeek;

        for (int i = 0; i < startDay; i++)
        {
            Console.Write("    ");
        }
        
        int daysInMonth = DateTime.DaysInMonth(year, month);
        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day,3} ");

            if ((startDay + day) % 7 == 0)
                Console.WriteLine();
        }

        Console.WriteLine("\n");
    }
}
