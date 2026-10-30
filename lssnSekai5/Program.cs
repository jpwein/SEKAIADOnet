using System;
using Microsoft.Data.SqlClient;

namespace Lesson05
{
    internal class Program
    {
        private static string connStr = "Server=localhost;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("=== Урок 5: ===");
            ShowAllStudents();
            FindStudentByName("Иван");
            AddGroup("ПИ-22");
            AddStudent("Алексей", "Петров", "19", "1");
        }

        static void ShowAllStudents()
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();
            using var cmd = new SqlCommand("SELECT * FROM Students", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"[Студент] {reader["FirstName"]} {reader["LastName"]}, Возраст: {reader["Age"]}");
            }
        }

        static void FindStudentByName(string name)
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();
            using var cmd = new SqlCommand("SELECT * FROM Students WHERE FirstName = @Name", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"[Найден] {reader["FirstName"]} {reader["LastName"]}");
            }
        }

        static void AddGroup(string name_group)
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();
            using var cmd = new SqlCommand("INSERT INTO Groups (Name) VALUES (@Name)", conn);
            cmd.Parameters.AddWithValue("@Name", name_group);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Группа {name_group} добавлена.");
        }

        static void AddStudent(string first_name, string last_name, string age, string group_id)
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();
            using var cmd = new SqlCommand("INSERT INTO Students (FirstName, LastName, Age, GroupId) VALUES (@fn, @ln, @age, @gid)", conn);
            cmd.Parameters.AddWithValue("@fn", first_name);
            cmd.Parameters.AddWithValue("@ln", last_name);
            cmd.Parameters.AddWithValue("@age", int.Parse(age));
            cmd.Parameters.AddWithValue("@gid", int.Parse(group_id));
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Студент {first_name} {last_name} добавлен.");
        }
    }
}
