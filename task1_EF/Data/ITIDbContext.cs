using Microsoft.EntityFrameworkCore;
using task1_EF.Models;

namespace task1_EF.Data
{
    public class ITIDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MVClab3;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // on table
            modelBuilder.Entity<Course>().HasKey(a => a.CrsId);
            // on selected property (column) >> name
            modelBuilder.Entity<Course>().Property(a => a.CrsName).IsRequired();

            // composite primary key (in fluent API only)
            modelBuilder.Entity<StudentCourse>().HasKey(a => new { a.StdId, a.CrsId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
