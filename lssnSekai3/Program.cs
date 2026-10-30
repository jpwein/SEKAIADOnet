using System;
using Microsoft.Data.SqlClient;

namespace Lesson03
{
    internal class Program
    {
        private static string connectionString = "Server=localhost;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("=== Урок 3: C# + System.Data.SqlClient ===");
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, FirstName, LastName FROM Students";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"[ID: {reader["Id"]}] {reader["FirstName"]} {reader["LastName"]}");
                    }
                }
            }
        }
    }
}
