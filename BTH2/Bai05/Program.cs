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

        List<KhuDat> ds = new List<KhuDat>();

        while (true)
        {
            Console.WriteLine("\n===== QUẢN LÝ BẤT ĐỘNG SẢN =====");
            Console.WriteLine("1. Thêm một địa điểm (Khu đất, nhà phố, chung cư)");
            Console.WriteLine("2. Danh sách các địa điểm quản lý");
            Console.WriteLine("3. Tổng giá bán theo từng loại địa điểm");
            Console.WriteLine("4. Danh sách khu đất > 100m2, nhà phố với diện tích > 60m2 và năm xây dựng từ 2019");
            Console.WriteLine("5. Tìm kiếm địa điểm phù hợp");
            Console.WriteLine("6. Thoát chương trình");
            Console.Write("Chọn thao tác: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    NhapMotDiaDiem(ds);
                    break;

                case "2":
                    XuatDanhSach(ds);
                    break;

                case "3":
                    TinhTongGiaBan(ds);
                    break;

                case "4":
                    TimKiemCoDinh(ds);
                    break;

                case "5":
                    TimKiemTheoYeuCau(ds);
                    break;

                case "6":
                    Console.WriteLine("Đã thoát chương trình.");
                    return;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                    break;
            }
        }
    }

    static void NhapMotDiaDiem(List<KhuDat> ds)
    {
        Console.WriteLine("\n--- Nhập thông tin địa điểm ---");
        Console.Write("Chọn loại địa điểm (1.Khu đất, 2.Nhà phố, 3.Chung cư): ");

        string input = Console.ReadLine()?.Trim();
        KhuDat obj = input switch
        {
            "1" => new KhuDat(),
            "2" => new NhaPho(),
            "3" => new ChungCu(),
            _ => null
        };

        if (obj == null)
        {
            Console.WriteLine("Loại địa điểm không hợp lệ, vui lòng thử lại.");
            return;
        }

        obj.Nhap();
        ds.Add(obj);
        Console.WriteLine("Đã thêm địa điểm thành công!");
    }

    static void XuatDanhSach(List<KhuDat> ds)
    {
        if (ds.Count == 0)
        {
            Console.WriteLine("Không có địa điểm nào đang quản lý");
            return;
        }

        Console.WriteLine("\n--- Danh sách địa điểm đang quản lý ---");
        foreach (var item in ds)
        {
            item.Xuat();
            Console.WriteLine();
        }
    }

    static void TinhTongGiaBan(List<KhuDat> ds)
    {
        double tongDat = ds.Where(x => x is KhuDat && !(x is NhaPho) && !(x is ChungCu)).Sum(x => x.GiaBan);
        double tongNhaPho = ds.OfType<NhaPho>().Sum(x => x.GiaBan);
        double tongChungCu = ds.OfType<ChungCu>().Sum(x => x.GiaBan);

        Console.WriteLine($"\nTổng giá bán Khu đất: {tongDat:N0} VND");
        Console.WriteLine($"Tổng giá bán Nhà phố: {tongNhaPho:N0} VND");
        Console.WriteLine($"Tổng giá bán Chung cư: {tongChungCu:N0} VND");
    }

    static void TimKiemCoDinh(List<KhuDat> ds)
    {
        var ketQua = ds.Where(x =>
            (x is KhuDat && !(x is NhaPho) && !(x is ChungCu) && x.DienTich > 100) ||
            (x is NhaPho np && np.DienTich > 60 && np.NamXayDung >= 2019)
        );

        if (!ketQua.Any())
        {
            Console.WriteLine("Không có địa điểm thỏa điều kiện.");
            return;
        }

        Console.WriteLine("\n--- Danh sách địa điểm đáp ứng yêu cầu ---");
        foreach (var item in ketQua)
        {
            item.Xuat();
            Console.WriteLine();
        }
    }

    static void TimKiemTheoYeuCau(List<KhuDat> ds)
    {

        Console.Write("\nNhập địa điểm cần tìm: ");
        string diaDiemTK = Console.ReadLine().ToLower();

        double giaTK;
        while (true)
        {
            Console.Write("Nhập giá tối đa: ");
            if (double.TryParse(Console.ReadLine(), out giaTK))
                break;
            Console.WriteLine("Giá không hợp lệ, vui lòng nhập lại!");
        }

        double dienTichTK;
        while (true)
        {
            Console.Write("Nhập diện tích tối thiểu: ");
            if (double.TryParse(Console.ReadLine(), out dienTichTK))
                break;
            Console.WriteLine("Diện tích không hợp lệ, vui lòng nhập lại!");
        }

        var timKiem = ds.Where(x =>
            (x is NhaPho || x is ChungCu) &&
            x.DiaDiem.ToLower().Contains(diaDiemTK) &&
            x.GiaBan <= giaTK &&
            x.DienTich >= dienTichTK
        );

        Console.WriteLine("\n--- Kết quả tìm kiếm ---");
        if (!timKiem.Any())
            Console.WriteLine("Không tìm thấy kết quả phù hợp.");
        else
        {
            foreach (var item in timKiem)
            {
                item.Xuat();
                Console.WriteLine();
            }
        }

    }
}