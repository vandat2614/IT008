
class NhaPho : KhuDat
{
    public int NamXayDung { get; set; }
    public int SoTang { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhập năm xây dựng: ");
        NamXayDung = int.Parse(Console.ReadLine());
        Console.Write("Nhập số tầng: ");
        SoTang = int.Parse(Console.ReadLine());
    }

    public override void Xuat()
    {
        Console.WriteLine($"[Nhà phố]" +
            $"\n\tĐịa điểm: {DiaDiem}" +
            $"\n\tGiá bán: {GiaBan:N0} VND" +
            $"\n\tDiện tích: {DienTich} m2" +
            $"\n\tNăm xây dựng: {NamXayDung}" +
            $"\n\tSố tầng: {SoTang}");
    }
}
