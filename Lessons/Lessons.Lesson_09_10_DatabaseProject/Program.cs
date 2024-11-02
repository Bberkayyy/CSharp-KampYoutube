using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_09_10_DatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ado.net

            Console.WriteLine("****** C# Veri Tabanlı Ürün-Kategori Bilgi Sistemi ******");
            Console.WriteLine();
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EgitimKampiDb;Integrated Security=True");

            string selectedOperation;
            string query;

            while (true)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1 - Kategoriler");
                Console.WriteLine("2 - Ürünler");
                Console.WriteLine("3 - Siparişler");
                Console.WriteLine("4 - Kategori Ekle");
                Console.WriteLine("5 - Ürün Ekle");
                Console.WriteLine("6 - Çıkış Yap");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz.");
                Console.WriteLine();
                selectedOperation = Console.ReadLine();
                Console.WriteLine();

                switch (selectedOperation)
                {
                    case "1":
                        query = "Select * from TblCategory";
                        GetDataTable(query, conn);
                        break;
                    case "2":
                        query = "Select * from TblProduct";
                        GetDataTable(query, conn);
                        break;
                    case "3":
                        query = "Select * from TblOrder";
                        GetDataTable(query, conn);
                        break;
                    case "4":
                        Console.Write("Kategori Adı Giriniz : ");
                        string categoryName = Console.ReadLine();
                        AddCategory(conn, categoryName);
                        break;
                    case "5":
                        Console.Write("Ürün Adı : ");
                        string productName = Console.ReadLine();
                        Console.Write("Ürün Fiyatı : ");
                        decimal productPrice = decimal.Parse(Console.ReadLine());
                        AddProduct(conn, productName, productPrice);
                        break;
                    case "6":
                        Console.WriteLine("Uygulama kapanıyor...");
                        Environment.Exit(0);
                        break;
                    default:
                        if (string.IsNullOrEmpty(selectedOperation))
                            Console.WriteLine("Boş veya geçersiz bir değer girdiniz.");
                        else
                            Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyiniz.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void GetDataTable(string query, SqlConnection conn)
        {
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item.ToString() + "  ");
                }
                Console.WriteLine();
            }
            conn.Close();
        }
        static void AddCategory(SqlConnection conn, string categoryName)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("insert into TblCategory (Name) values (@categoryName)", conn);
            command.Parameters.AddWithValue("@categoryName", categoryName);
            command.ExecuteNonQuery();
            conn.Close();
        }
        static void AddProduct(SqlConnection conn, string productName, decimal productPrice, bool productStatus = true)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("insert into TblProduct (Name,Price,Status) values (@productName,@productPrice,@productStatus)", conn);
            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@productPrice", productPrice);
            command.Parameters.AddWithValue("@productStatus", productStatus);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
