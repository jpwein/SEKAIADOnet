using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CollegeApp.Models;

namespace CollegeApp.Data
{
    public class StudentRepository
    {
        private readonly string _connectionString;
        public StudentRepository(string connectionString) => _connectionString = connectionString;

        public List<Student> GetAll()
        {
            var list = new List<Student>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT Id, FirstName, LastName, Age, GroupId FROM Students", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Age = reader.GetInt32(3),
                    GroupId = reader.GetInt32(4)
                });
            }
            return list;
        }
    }
}
