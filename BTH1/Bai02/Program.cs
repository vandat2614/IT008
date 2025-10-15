using System;
using System.Text;

class Program
{
    static void Main()
    {

        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        int sum = 0;
        Console.Write($"Danh sách các số nguyên tố < {n} gồm: ");
        for(int i = 2; i < n; i++)
        {
            if (IsPrime(i))
            {
                sum += i;
                Console.Write($"{i} ");
            }
        }

        Console.WriteLine($"\nTổng các số nguyên tó < {n} là: {sum}");
    }

    static bool IsPrime(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}
