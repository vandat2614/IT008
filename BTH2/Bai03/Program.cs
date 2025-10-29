using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int[,] matrix = InputMatrix();

        Console.WriteLine("\nMa trận khởi tạo:\n");
        PrintMatrix(matrix);

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Tìm kiếm một phần tử trong ma trận");
            Console.WriteLine("2. Xuất các phần tử là số nguyên tố");
            Console.WriteLine("3. Cho biết dòng có nhiều số nguyên tố nhất");
            Console.WriteLine("4. Thoát");
            Console.Write("Chọn chức năng: ");

            string choice = Console.ReadLine().Trim().ToLower();

            switch (choice)
            {
                case "1":
                    Console.Write("\nNhập giá trị cần tìm: ");
                    int target = int.Parse(Console.ReadLine());
                    var found = Find(matrix, target);

                    if (found.Count > 0)
                    {
                        Console.Write($"Các vị trí tìm thấy giá trị {target} gồm (row, col) = ");
                        Console.Write("{ ");
                        for (int i = 0; i < found.Count; i++)
                        {
                            var pos = found[i];
                            Console.Write($"({pos.Item1}, {pos.Item2})");
                            if (i < found.Count - 1)
                                Console.Write(", ");
                        }
                        Console.WriteLine(" }");
                    }
                    else
                        Console.WriteLine("Không tìm thấy phần tử!");
                    break;

                case "2":
                    var primes = FindPrime(matrix);
                    if (primes.Count > 0)
                    {
                        Console.Write("\nCác số nguyên tố trong ma trận: ");
                        Console.WriteLine(string.Join(", ", primes));
                    }
                    else
                        Console.WriteLine("Không có số nguyên tố trong ma trận.");
                    break;

                case "3":
                    var primeCounts = GetPrimeByRow(matrix);
                    int maxCount = primeCounts.Max();

                    var maxRows = new List<int>();
                    for (int i = 0; i < primeCounts.Count; i++)
                        if (primeCounts[i] == maxCount)
                            maxRows.Add(i + 1);

                    Console.WriteLine($"\nDòng có nhiều số nguyên tố nhất ({maxCount} số nguyên tố): {string.Join(", ", maxRows)}");
                    break;

                case "4":
                    Console.WriteLine("Đã thoát chương trình.");
                    return;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                    break;
            }
        }
    }

    static int[,] InputMatrix()
    {
        Console.Write("Nhập số hàng của ma trận, n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Nhập số cột của ma trận, m = ");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine();

        int[,] matrix = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Nhập phần tử M[{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    static List<(int, int)> Find(int[,] matrix, int target)
    {
        List<(int, int)> result = new List<(int, int)>();
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (matrix[i, j] == target)
                    result.Add((i, j));

        return result;
    }

    static bool IsPrime(int x)
    {
        if (x < 2)
            return false;
        for (int i = 2; i <= Math.Sqrt(x); i++)
            if (x % i == 0)
                return false;
        return true;
    }

    static List<int> FindPrime(int[,] matrix)
    {
        List<int> primes = new List<int>();
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (IsPrime(matrix[i, j]) && !primes.Contains(matrix[i, j]))
                    primes.Add(matrix[i, j]);
        return primes;
    }

    static List<int> GetPrimeByRow(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        List<int> countPerRow = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < m; j++)
                if (IsPrime(matrix[i, j]))
                    count++;
            countPerRow.Add(count);
        }

        return countPerRow;
    }
}
