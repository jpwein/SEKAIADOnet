using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using CollegeApp.Models;

namespace CollegeApp.Data
{
    public class StudentRepository
    {
        private readonly string _connectionString;
        public StudentRepository(string connectionString) => _connectionString = connectionString;

        public IEnumerable<Student> GetAll()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<Student>("SELECT * FROM Students");
        }

        public Student GetById(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.QueryFirstOrDefault<Student>("SELECT * FROM Students WHERE Id = @Id", new { Id = id });
        }

        public int CreateStudent(Student student)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string sql = "INSERT INTO Students (FirstName, LastName, Age, GroupId) VALUES (@FirstName, @LastName, @Age, @GroupId); SELECT CAST(SCOPE_IDENTITY() as int);";
            return db.QuerySingle<int>(sql, student);
        }
    }
}
