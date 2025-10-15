using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Nhập ngày: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Nhập tháng: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Nhập năm: ");
        int year = int.Parse(Console.ReadLine());

        if (IsValidDate(day, month, year))
            Console.WriteLine($"\nNgày {day}/{month}/{year} là ngày hợp lệ.");
        else
            Console.WriteLine($"\nNgày {day}/{month}/{year} không hợp lệ.");
    }

    static bool IsValidDate(int day, int month, int year)
    {
        if (year < 1 || month < 1 || month > 12 || day < 1)
            return false;

        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (IsLeapYear(year))
            daysInMonth[1] = 29;

        if (day > daysInMonth[month - 1])
            return false;

        return true;
    }

    static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }
}
