using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    public class ExamRepository : IExamRepository
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

        public void Update(Exam exam, Exam newExam)
        {
            foreach (var question in exam.Questions)
            {
                exam.Remove(question);
            }
            exam.Insert(newExam.Questions);

            exam.Course = newExam.Course;
            exam.Instructions = newExam.Instructions;
            exam.Title = newExam.Title;
            exam.Type = newExam.Type;
        }
    }
}