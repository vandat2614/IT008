using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Nhập số hàng của ma trận, n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Nhập số cột của ma trận, m = ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, m];
        Random rand = new Random();

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                matrix[i, j] = rand.Next(0, 100);

        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENU CHƯƠNG TRÌNH MA TRẬN ===");
            Console.WriteLine("1. In ma trận");
            Console.WriteLine("2. Tìm giá trị nhỏ nhất và lớn nhất");
            Console.WriteLine("3. Tìm hàng có tổng lớn nhất");
            Console.WriteLine("4. Tính tổng các số KHÔNG phải số nguyên tố");
            Console.WriteLine("5. Xóa một dòng");
            Console.WriteLine("6. Xóa cột chứa phần tử lớn nhất");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Ma trận hiện tại:");
                    PrintMatrix(matrix);
                    break;

                case 2:
                    (int min, int max) = GetMinMax(matrix);
                    Console.WriteLine($"Giá trị nhỏ nhất: {min}, Giá trị lớn nhất: {max}");
                    break;

                case 3:
                    Console.WriteLine($"Hàng có tổng lớn nhất là: {GetMaxSumRow(matrix) + 1}");
                    break;

                case 4:
                    Console.WriteLine($"Tổng các số không phải số nguyên tố: {SumNonPrime(matrix)}");
                    break;

                case 5:
                    Console.Write($"Nhập dòng cần xóa (1 → {matrix.GetLength(0)}): ");
                    int k = int.Parse(Console.ReadLine());
                    if (k < 1 || k > matrix.GetLength(0))
                    {
                        Console.WriteLine("Dòng không hợp lệ!");
                    }
                    else
                    {
                        matrix = DeleteRow(matrix, k - 1);
                        Console.WriteLine($"Đã xóa dòng {k}. Ma trận sau khi xóa:");
                        PrintMatrix(matrix);
                    }
                    break;

                case 6:
                    (int row, int col) = GetMaxPos(matrix);
                    matrix = DeleteCol(matrix, col);
                    Console.WriteLine($"Đã xóa cột chứa phần tử lớn nhất (cột {col + 1}):");
                    PrintMatrix(matrix);
                    break;

                case 0:
                    Console.WriteLine("Đã thoát chương trình.");
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                    break;
            }

            if (choice != 0)
            {
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }

        } while (choice != 0);
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write($"{matrix[i, j],4}");
            Console.WriteLine();
        }
    }

    static (int, int) GetMinMax(int[,] matrix)
    {
        int min = matrix[0, 0], max = matrix[0, 0];
        foreach (int x in matrix)
        {
            if (x < min) min = x;
            if (x > max) max = x;
        }
        return (min, max);
    }

    static int GetMaxSumRow(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int maxSum = int.MinValue;
        int maxRowIndex = -1;

        for (int i = 0; i < rows; i++)
        {
            int sum = 0;
            for (int j = 0; j < cols; j++)
                sum += matrix[i, j];

            if (sum > maxSum)
            {
                maxSum = sum;
                maxRowIndex = i;
            }
        }
        return maxRowIndex;
    }

    static (int, int) GetMaxPos(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int best = int.MinValue, row_index = -1, col_index = -1;

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (matrix[i, j] > best)
                {
                    best = matrix[i, j];
                    row_index = i;
                    col_index = j;
                }

        return (row_index, col_index);
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }

    static int SumNonPrime(int[,] matrix)
    {
        int sum = 0;
        foreach (int x in matrix)
            if (!IsPrime(x))
                sum += x;
        return sum;
    }

    static int[,] DeleteRow(int[,] matrix, int row_index)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows - 1, cols];
        int newRow = 0;

        for (int i = 0; i < rows; i++)
        {
            if (i == row_index) continue;
            for (int j = 0; j < cols; j++)
                result[newRow, j] = matrix[i, j];
            newRow++;
        }
        return result;
    }

    static int[,] DeleteCol(int[,] matrix, int col_index)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols - 1];
        int newCol = 0;

        for (int i = 0; i < cols; i++)
        {
            if (i == col_index) continue;
            for (int j = 0; j < rows; j++)
                result[j, newCol] = matrix[j, i];
            newCol++;
        }
        return result;
    }
}
