using System;
using System.Text;
using System.Globalization;

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

        DateTime date = new DateTime(year, month, day);
        string thuTiengViet = ConvertToVN(date.DayOfWeek);
        Console.WriteLine($"\nNgày {date:dd/MM/yyyy} là {thuTiengViet}");
    }

    static string ConvertToVN(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return "Thứ Hai";
            case DayOfWeek.Tuesday: return "Thứ Ba";
            case DayOfWeek.Wednesday: return "Thứ Tư";
            case DayOfWeek.Thursday: return "Thứ Năm";
            case DayOfWeek.Friday: return "Thứ Sáu";
            case DayOfWeek.Saturday: return "Thứ Bảy";
            case DayOfWeek.Sunday: return "Chủ Nhật";
            default: return "";
        }
    }
}
