namespace CollegeApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"Группа: {Name} (ID: {Id})";
    }
}
