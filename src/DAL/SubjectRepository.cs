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
            new Subject("Educazione alimentare",1),
            new Subject("Sistema scheletrico",2),
            new Subject("La cellula",3)
        };

        public Subject GetByTitle(string title)
        {
            return Subjects.FirstOrDefault(x => x.Title == title);
        }

        public IEnumerable<Subject> GetAll()
        {
            return Subjects;
        }

        public Subject GetById(int subjectId)
        {
            return Subjects.FirstOrDefault(x => x.Id == subjectId);
        }
    }
}