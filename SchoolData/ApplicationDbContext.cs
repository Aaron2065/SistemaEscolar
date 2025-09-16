using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Models;

namespace SchoolData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
    }
}
