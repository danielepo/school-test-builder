using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    public class ProfessorRepository : IProfessorRepository
    {
        private static HashSet<Professor> professors = new HashSet<Professor>();
        private EntityDbContext context;
        public ProfessorRepository(EntityDbContext context)
        {
            this.context = context;
        }

        public Professor GetById(string id)
        {
            return context.Professors.First(x => x.ProfessorId.Equals(new Guid(id)));
        }

        public IEnumerable<Professor> GetAll()
        {
            return context.Professors;
        }

        public void Insert(Professor prof)
        {
            context.Professors.Add(prof);
            context.SaveChanges();
        }
    }
}