using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizH.Models;
using Entities;

namespace QuizH.Data
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions options) : base(options)
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
            builder.Entity<Question>().HasOne(x => x.Professor);
            builder.Entity<Question>().HasOne(x => x.Subject);
            builder.Entity<Question>().HasMany(x => x.Choiches);
            builder.Entity<Question>().HasMany(x => x.Courses);

            builder.Entity<Exam>().HasMany(x => x.Questions);
            builder.Entity<Exam>().HasOne(x => x.Course);
        }
    }
}
