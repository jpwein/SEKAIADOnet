using System;
using CollegeApp.Data;
using CollegeApp.Models;

namespace Lesson07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Server=localhost;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;";
            var studentRepo = new StudentRepository(connStr);
            
            Console.WriteLine("=== ===");
            foreach (var st in studentRepo.GetAll())
            {
                Console.WriteLine(st);
            }
        }
    }
}
