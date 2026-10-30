using System.Collections.Generic;
using CollegeAPI.Models;

namespace CollegeAPI.Data
{
    public class StudentRepository
    {
        public IEnumerable<Student> GetAll() => new List<Student>
        {
            new Student { Id = 1, FirstName = "Иван", LastName = "Иванов", Age = 20, GroupId = 1 }
        };
    }
}
