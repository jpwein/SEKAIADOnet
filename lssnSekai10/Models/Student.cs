namespace CollegeApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int GroupId { get; set; }

        public override string ToString() => $"[ID: {Id}] {FirstName} {LastName}, Возраст: {Age}";
    }
}
