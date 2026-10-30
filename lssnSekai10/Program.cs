using System;
using CollegeApp.Data;
using CollegeApp.Models;

namespace Lesson10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Server=localhost;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;";
            var studentRepo = new StudentRepository(connStr);
            
            Console.WriteLine("=== Урок 10: Репозитории и данные ===");
            foreach (var st in studentRepo.GetAll())
            {
                Console.WriteLine(st);
            }
        }
    }
}
