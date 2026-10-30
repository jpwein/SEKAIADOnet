using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using CollegeApp.Models;

namespace CollegeApp.Data
{
    public class GroupRepository
    {
        private readonly string _connectionString;
        public GroupRepository(string connectionString) => _connectionString = connectionString;

        public IEnumerable<Group> GetAll()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<Group>("SELECT * FROM Groups");
        }
    }
}
