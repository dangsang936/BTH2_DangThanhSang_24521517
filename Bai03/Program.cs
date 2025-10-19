using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int rows=1, cols=1;
            int[,] matrix = new int[1,1];
            bool matrix_empty = true;
            //In menu
            while (true)
            {
                Console.WriteLine("\n----------------------MENU----------------------");
                Console.WriteLine("1. Nhập ma trận");
                Console.WriteLine("2. In ma trận");
                Console.WriteLine("3. Tìm kiếm một phần tử trong ma trận");
                Console.WriteLine("4. In các phần tử là số nguyên tố trong ma trận");
                Console.WriteLine("5. Dòng có nhiều số nguyên tố nhất");
                Console.WriteLine("6. Thoát");
                Console.WriteLine("------------------------------------------------");
                int choice;
                while (true)
                {
                    Console.Write("Chọn chức năng (1-6): ");
                    choice = int.Parse(Console.ReadLine());
                    if (choice >= 1 && choice <= 6)
                        break;
                    else
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                }
                switch (choice)
                {
                    case 1:
                        matrix = Input_Matrix(out rows, out cols);
                        matrix_empty = false;
                        break;
                    case 2:
                        if (matrix_empty)
                            Console.WriteLine("Ma trận chưa được nhập. Vui lòng nhập ma trận trước.");
                        else                                                   
                            Print_Matrix(matrix, rows, cols);
                        break;
                    case 3:
                        if (matrix_empty)
                            Console.WriteLine("Ma trận chưa được nhập. Vui lòng nhập ma trận trước.");
                        else
                        {
                            Console.Write("Nhập phần tử cần tìm: ");
                            int x = int.Parse(Console.ReadLine());
                            bool found = Find_Element(matrix, rows, cols, x);
                            if (found)
                                Console.WriteLine($"Phần tử {x} có trong ma trận.");
                            else
                                Console.WriteLine($"Phần tử {x} không có trong ma trận.");
                        }
                        break;
                    case 4:
                        if (matrix_empty)
                            Console.WriteLine("Ma trận chưa được nhập. Vui lòng nhập ma trận trước.");
                        else
                            Print_Prime_Elements(matrix, rows, cols);
                        break;
                    case 5:
                        if (matrix_empty)
                            Console.WriteLine("Ma trận chưa được nhập. Vui lòng nhập ma trận trước.");
                        else
                        {
                            int rowIndex = Row_With_Most_Primes(matrix, rows, cols);
                            if (rowIndex != -1)
                                Console.WriteLine($"Dòng có nhiều số nguyên tố nhất là dòng {rowIndex} (bắt đầu từ 0).");
                            else
                                Console.WriteLine("Không có dòng nào chứa số nguyên tố.");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Thoát chương trình.");
                        return;
                }
            }
        }

        //(a) Hàm nhập ma trận từ bàn phím và trả về ma trận cùng số hàng và số cột
        public static int[,] Input_Matrix(out int rows, out int cols)
        {
            while (true)
            {
                Console.Write("Nhập số hàng của ma trận: ");
                rows = int.Parse(Console.ReadLine());
                Console.Write("Nhập số cột của ma trận: ");
                cols = int.Parse(Console.ReadLine());
                if (rows > 0 && cols > 0)
                    break;
                else
                    Console.WriteLine("Số hàng và số cột phải là số nguyên dương. Vui lòng nhập lại.");
            }
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Nhập phần tử tại vị trí [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }

        //(a) Hàm in ma trận ra màn hình
        public static void Print_Matrix(int[,] matrix, int rows, int cols)
        {
            Console.WriteLine("Ma trận đã nhập:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        //(b) Hàm tìm kiếm một phần tử x trong ma trận, trả về true nếu tìm thấy, ngược lại trả về false
        public static bool Find_Element(int[,] matrix, int rows, int cols, int x)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == x)
                        return true;
                }
            }
            return false;
        }
        //(c) Hàm kiểm tra một số nguyên tố
        public static bool Is_Prime(int n)
        {
            if (n < 2)
                return false;
            if (n <= 3)
                return true;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        //(c) Hàm in các phần tử là số nguyên tố trong ma trận
        public static void Print_Prime_Elements(int[,] matrix, int rows, int cols)
        {
            Console.WriteLine("Các phần tử là số nguyên tố trong ma trận:");
            foreach (int i in matrix)
                if (Is_Prime(i))
                    Console.Write(i + " ");
            Console.WriteLine();
        }

        //(d) hàm đếm dòng nào có nhiều số nguyên tố nhất
        public static int Row_With_Most_Primes(int[,] matrix, int rows, int cols)
        {
            int maxCount = 0;
            int rowIndex = -1;
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (Is_Prime(matrix[i, j]))
                        count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    rowIndex = i;
                }
            }
            return rowIndex;
        }
    }
}
