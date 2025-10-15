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

        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (IsLeapYear(year))
            daysInMonth[1] = 29;

        int num_days = daysInMonth[month - 1];
        Console.WriteLine($"Tháng {month}, năm {year} có {num_days} ngày");
    }

    static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }
}
