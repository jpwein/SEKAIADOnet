using System;
using Microsoft.Data.SqlClient;

namespace Lesson04
{
    internal class Program
    {
        private static string connectionString = "Server=localhost;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- МЕНЮ ---");
                Console.WriteLine("1. Показать всех студентов");
                Console.WriteLine("2. Найти студента по ID");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите пункт: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllProducts();
                        break;
                    case "2":
                        Console.Write("Введите ID: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            GetStudentById(id);
                        }
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
        }

        static void ShowAllProducts()
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT Id, FirstName, LastName FROM Students", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]} | {reader["FirstName"]} {reader["LastName"]}");
            }
        }

        static void GetStudentById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT Id, FirstName, LastName FROM Students WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Найден: {reader["FirstName"]} {reader["LastName"]}");
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }
    }
}
