using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class SubjectRepository : ISubjectRepository
    { private EntityDbContext context;
        public SubjectRepository(EntityDbContext context)
        {
            this.context = context;
            if (!context.Subjects.Any())
            {
                context.Subjects.AddRange(Subjects);
            context.SaveChanges();
            }
        }
        private List<Subject> Subjects = new List<Subject>
        {
            new Subject("Educazione alimentare",1),
            new Subject("Sistema scheletrico",2),
            new Subject("La cellula",3)
        };

        public Subject GetByTitle(string title)
        {
            return context.Subjects.FirstOrDefault(x => x.Title == title);
        }

        public IEnumerable<Subject> GetAll()
        {
            return context.Subjects;
        }

        public Subject GetById(int subjectId)
        {
            return context.Subjects.FirstOrDefault(x => x.SubjectId == subjectId);
        }

        public async Task Insert(Subject subject)
        {
            await context.Subjects.AddAsync(subject);
            await context.SaveChangesAsync();
        }
    }
}