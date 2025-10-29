using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Nhập đường dẫn thư mục: ");
        string path = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("\nThư mục không tồn tại!");
            return;
        }

        Console.WriteLine($"\n Directory of {path}\n");

        string[] dirs = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path);

        int dirCount = 0;
        int fileCount = 0;
        long totalSize = 0;

        foreach (string dir in dirs)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            Console.WriteLine($"{di.LastWriteTime:dd/MM/yyyy hh:mm tt}    <DIR>          {di.Name}");
            dirCount++;
        }

        foreach (string file in files)
        {
            FileInfo fi = new FileInfo(file);
            Console.WriteLine($"{fi.LastWriteTime:dd/MM/yyyy hh:mm tt}    {fi.Length,15:N0} {fi.Name}");
            fileCount++;
            totalSize += fi.Length;
        }

        Console.WriteLine($"\n{fileCount} File(s)\t{totalSize:N0} bytes");
        Console.WriteLine($"{dirCount} Dir(s)\t{GetFreeSpace(path):N0} bytes free");
    }

    static long GetFreeSpace(string path)
    {
        string root = Path.GetPathRoot(path);
        DriveInfo drive = new DriveInfo(root);
        return drive.AvailableFreeSpace;
    }
}
