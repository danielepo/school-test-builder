using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    public class ProfessorRepository : IProfessorRepository
    {
        private static HashSet<Professor> professors = new HashSet<Professor>();

        public Professor GetById(string id)
        {
            return professors.First(x => x.ProfessorId.Equals(new Guid(id)));
        }

        public IEnumerable<Professor> GetAll()
        {
            return professors;
        }

        public void Insert(Professor prof)
        {
            professors.Add(prof);
        }
    }
}