using Entities;
using Microsoft.EntityFrameworkCore;

namespace QuizH.Data
{
    public class EntitiesDbContext: DbContext
    {
        public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options) : base(options) { }
        public EntitiesDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}