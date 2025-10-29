using System;
using System.Collections.Generic;
using System.Linq;

class Fraction : IComparable<Fraction>
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");

        Numerator = numerator;
        Denominator = denominator;
        Simplify();
    }

    private void Simplify()
    {
        int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
        Numerator /= gcd;
        Denominator /= gcd;
        if (Denominator < 0)
        {
            Numerator *= -1;
            Denominator *= -1;
        }
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }

    public static Fraction operator +(Fraction a, Fraction b)
        => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                        a.Denominator * b.Denominator);

    public static Fraction operator -(Fraction a, Fraction b)
        => new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                        a.Denominator * b.Denominator);

    public static Fraction operator *(Fraction a, Fraction b)
        => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Cannot divide by zero fraction.");
        return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    public double ToDouble() => (double)Numerator / Denominator;

    public override string ToString() => $"{Numerator}/{Denominator}";

    public int CompareTo(Fraction other)
    {
        double diff = this.ToDouble() - other.ToDouble();
        if (diff > 0) return 1;
        if (diff < 0) return -1;
        return 0;
    }
}
