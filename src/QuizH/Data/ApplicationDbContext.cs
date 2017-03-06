using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizH.Models;

namespace QuizH.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Exam>().HasKey(x => x.ExamId);
            var builder = modelBuilder.Entity<Question>();
            builder.HasOne(x => x.Professor);
            builder.HasOne(x => x.Subject);
            builder.HasKey(x => x.QuestionId);
            builder.HasMany(x => x.Choiches);


            modelBuilder.Entity<Professor>().HasKey(x => x.ProfessorId);
            modelBuilder.Entity<Answer>().HasKey(x => x.AnswerId);
            modelBuilder.Entity<Course>().HasKey(x => x.CourseId);
            modelBuilder.Entity<Subject>().HasKey(x => x.SubjectId);

        }
        // DbSet of our Product class 
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Subject> Subject { get; set; }

    }
}
