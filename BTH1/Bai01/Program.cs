using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Nhập số phần tử của mảng, n = ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = CreateArray(n);

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. In mảng");
            Console.WriteLine("2. Tính tổng các số lẻ");
            Console.WriteLine("3. Đếm số nguyên tố");
            Console.WriteLine("4. Tìm số chính phương nhỏ nhất");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Vui lòng nhập số hợp lệ!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nMảng hiện tại: " + string.Join(", ", arr));
                    break;

                case 2:
                    Console.WriteLine($"\nTổng các số lẻ trong mảng: {SumOdd(arr)}");
                    break;

                case 3:
                    Console.WriteLine($"\nMảng chứa {CountPrime(arr)} số nguyên tố");
                    break;

                case 4:
                    int found = GetMinPerfectSquare(arr);
                    if (found == -1)
                        Console.WriteLine("Không tồn tại số chính phương trong mảng");
                    else
                        Console.WriteLine($"Số chính phương nhỏ nhất trong mảng là {found}");
                    break;

                case 0:
                    Console.WriteLine("Đã thoát chương trình.");
                    return;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại!");
                    break;
            }
        }
    }

    static int[] CreateArray(int size)
    {
        int[] arr = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
            arr[i] = rand.Next(0, 100);

        return arr;
    }

    static int SumOdd(int[] arr)
    {
        int sum = 0;
        foreach (int x in arr)
            if (x % 2 != 0)
                sum += x;
        return sum;
    }

    static bool IsPrime(int n)
    {
        if (n < 2)
            return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0)
                return false;
        return true;
    }

    static int CountPrime(int[] arr)
    {
        int count = 0;
        foreach (int x in arr)
            if (IsPrime(x))
                count++;
        return count;
    }

    static bool IsPerfectSquare(int n)
    {
        if (n < 0)
            return false;
        int x = (int)Math.Sqrt(n);
        return x * x == n;
    }

    static int GetMinPerfectSquare(int[] arr)
    {
        int found = -1;
        foreach (int x in arr)
        {
            if (IsPerfectSquare(x))
            {
                if (found == -1 || x < found)
                    found = x;
            }
        }
        return found;
    }
}
