using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write("Nhập đường dẫn thư mục: ");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    Console.WriteLine("Thư mục hiện có là: " + dirInfo.FullName);
                    var allFile = dirInfo.GetFiles(); // Lấy tất cả các file trong thư mục                   
                    var allDir = dirInfo.GetDirectories(); // Lấy tất cả các thư mục con trong thư mục
                    int i = 0;
                    int j = 0;
                    while (i < allFile.Length || j < allDir.Length)
                    {
                        if (i >= allFile.Length)
                        {
                            Console.WriteLine($"{allDir[j].LastWriteTime:dd/MM/yyyy hh:mm tt}             <DIR>   {allDir[j].Name}");
                            j++;
                            continue;
                        }
                        if (j >= allDir.Length)
                        {
                            Console.WriteLine($"{allFile[i].LastWriteTime:dd/MM/yyyy hh:mm tt}   {allFile[i].Length,15:N0}   {allFile[i].Name}");
                            i++;
                            continue;
                        }
                        if (String.Compare(allFile[i].Name, allDir[j].Name, StringComparison.OrdinalIgnoreCase) <= 0)
                        {
                            Console.WriteLine($"{allFile[i].LastWriteTime:dd/MM/yyyy hh:mm tt}   {allFile[i].Length,15:N0}   {allFile[i].Name}");
                            i++;
                        }
                        else
                        {
                            Console.WriteLine($"{allDir[j].LastWriteTime:dd/MM/yyyy hh:mm tt}             <DIR>   {allDir[j].Name}");
                            j++;
                        }
                    }

                    // Tổng file
                    Console.WriteLine($"{allFile.Length} file(s) : {allFile.Sum(f => f.Length):N0} bytes");

                    // tổng thư mục                  
                    Console.WriteLine($"{allDir.Length} directorie(s) ");
                }
                else
                    Console.WriteLine("Đường dẫn thư mục không tồn tại.");
            }
        }

    
    }
}
