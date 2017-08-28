using CoreApp.DataAccess.Extensions;
using CoreApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.DataAccess.Persistance
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();
          
                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = property.Name.ToSnakeCase();
                }
            }

            modelBuilder.Entity<Student>().ToTable("Students")
                .HasKey(s => s.StudentId);
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments")
                .HasKey(e => new { e.StudentId, e.CourseId});
            modelBuilder.Entity<Course>().ToTable("Courses")
                .HasKey(c => c.CourseId);
            modelBuilder.Entity<Course>()
                .HasMany(s => s.Enrollments)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);
        }

        
    }
}
