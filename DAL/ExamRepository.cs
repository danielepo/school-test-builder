using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    public class ExamRepository
    {
        private static List<Exam> Exams = new List<Exam>();
        public Exam GetByTitle(string title)
        {
            return Exams.First(x => x.Title == title);
        }
        public IEnumerable<Exam> GetAll()
        {
            return Exams;
        }
        public void Insert(Exam exam)
        {
            Exams.Add(exam);
        }
    }
}