using System.Collections.Generic;
using Entities;

namespace DAL
{
    public interface IExamRepository
    {
        IEnumerable<Exam> GetAll();
        Exam GetByTitle(string title);
        void Insert(Exam exam);
        void Update(Exam exam, Exam newExam);
        Exam GetById(int id);
    }
}