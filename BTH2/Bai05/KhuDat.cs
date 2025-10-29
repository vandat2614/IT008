
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class KhuDat
{
    public string DiaDiem { get; set; }
    public double GiaBan { get; set; } 
    public double DienTich { get; set; } 

    public KhuDat() { }

    public KhuDat(string diaDiem, double giaBan, double dienTich)
    {
        DiaDiem = diaDiem;
        GiaBan = giaBan;
        DienTich = dienTich;
    }

    public virtual void Nhap()
    {
        Console.Write("Nhập địa điểm: ");
        DiaDiem = Console.ReadLine();

        Console.Write("Nhập giá bán (VND): ");
        GiaBan = double.Parse(Console.ReadLine());

        Console.Write("Nhập diện tích (m2): ");
        DienTich = double.Parse(Console.ReadLine());
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"[Khu đất]" +
            $"\n\tĐịa điểm: {DiaDiem}" +
            $"\n\tGiá bán: {GiaBan:N0} VND" +
            $"\n\tDiện tích: {DienTich} m2");
    }
}