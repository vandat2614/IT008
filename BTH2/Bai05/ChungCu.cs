class ChungCu : KhuDat
{
    public int Tang { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhập tầng: ");
        Tang = int.Parse(Console.ReadLine());
    }

    public override void Xuat()
    {
        Console.WriteLine($"[Chung cư] " +
            $"\n\tĐịa điểm: {DiaDiem}" +
            $"\n\tGiá bán: {GiaBan:N0} VND" +
            $"\n\tDiện tích: {DienTich} m2" +
            $"\n\tTầng: {Tang}");
    }
}
