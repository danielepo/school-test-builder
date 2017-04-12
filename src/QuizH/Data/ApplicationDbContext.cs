using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizH.Models;
using Entities;

namespace QuizH.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Entities.Exam> Exams { get; set; }
        public DbSet<Entities.Question> Questions { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.Professor> Professors { get; set; }
        public DbSet<Entities.Answer> Answers { get; set; }
        public DbSet<Entities.Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
