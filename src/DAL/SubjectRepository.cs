using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SubjectRepository : ISubjectRepository
    {
        private List<Subject> Subjects = new List<Subject>
        {
            new Subject("Educazione alimentare"),
            new Subject("Sistema scheletrico"),
            new Subject("La cellula")
        };

        public Subject GetByTitle(string title)
        {
            return Subjects.FirstOrDefault(x => x.Title == title);
        }

        public IEnumerable<Subject> GetAll()
        {
            return Subjects;
        }
    }
}