using Microsoft.EntityFrameworkCore;
using CollegeAPI.Models;

namespace CollegeAPI.Data
{
    public class CollegeDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;

        public CollegeDBContext(DbContextOptions<CollegeDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Group>().ToTable("Groups");
        }
    }
}
