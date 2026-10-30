using System.Collections.Generic;
using CollegeAPI.Models;

namespace CollegeAPI.Data
{
    public class GroupRepository
    {
        public IEnumerable<Group> GetAll() => new List<Group>
        {
            new Group { Id = 1, Name = "ПИ-21" }
        };
    }
}
