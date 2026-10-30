using Microsoft.EntityFrameworkCore;
using CollegeAPI.Models;

namespace CollegeAPI.Data
{
    public class CollegeDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;

        public CollegeDBContext(DbContextOptions<CollegeDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Group>().ToTable("Groups");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Grade>().ToTable("Grades");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
        }
    }
}
