using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Tính tổng, hiệu, tích và thương của hai phân số");
            Console.WriteLine("2. Tìm phân số lớn nhất và sắp xếp dãy phân số tăng dần");
            Console.WriteLine("3. Thoát");
            Console.Write("Chọn chức năng: ");
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    CalculateTwoFractions();
                    break;
                case "2":
                    ProcessFractionList();
                    break;
                case "3":
                    Console.WriteLine("Đã thoát chương trình.");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                    break;
            }
        }
    }

    static Fraction ReadFraction()
    {
        while (true)
        {
            string input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input) || !input.Contains('/'))
            {
                Console.Write("Sai định dạng! Vui lòng nhập lại (ts/ms): ");
                continue;
            }

            string[] parts = input.Split('/');
            if (parts.Length != 2)
            {
                Console.Write("Sai định dạng! Vui lòng nhập lại (ts/ms): ");
                continue;
            }

            bool ok1 = int.TryParse(parts[0], out int num);
            bool ok2 = int.TryParse(parts[1], out int den);

            if (!ok1 || !ok2)
            {
                Console.Write("Tử số và mẫu số phải là số nguyên! Nhập lại (ts/ms): ");
                continue;
            }

            if (den == 0)
            {
                Console.Write("Mẫu số không được bằng 0! Nhập lại (ts/ms): ");
                continue;
            }

            return new Fraction(num, den);
        }
    }

    static void CalculateTwoFractions()
    {
        Console.Write("Nhập phân số thứ nhất (ts/ms): ");
        Fraction f1 = ReadFraction();

        Console.Write("Nhập phân số thứ hai (ts/ms): ");
        Fraction f2 = ReadFraction();

        Console.WriteLine($"\n{f1} + {f2} = {f1 + f2}");
        Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
        Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
        Console.WriteLine($"{f1} / {f2} = {f1 / f2}");
    }

    static void ProcessFractionList()
    {
        Console.Write("\nNhập số lượng phân số, n = ");
        int n = int.Parse(Console.ReadLine());

        List<Fraction> fractions = new List<Fraction>();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập phân số thứ {i + 1} (ts/ms): ");
            fractions.Add(ReadFraction());
        }

        Fraction max = fractions.Max();
        Console.WriteLine($"\nPhân số lớn nhất: {max}");

        fractions.Sort();
        Console.Write("\nDanh sách phân số sắp xếp tăng dần: ");
        foreach (var f in fractions)
            Console.Write($"{f} ");
        Console.WriteLine();
    }
}
