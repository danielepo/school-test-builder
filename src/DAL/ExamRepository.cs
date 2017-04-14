using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Extensions;

namespace DAL
{
    public class ExamRepository : IExamRepository
    {
        private EntityDbContext context;
        public ExamRepository(EntityDbContext context)
        {
            this.context = context;
        }
        private static List<Exam> Exams = new List<Exam>();
        public Exam GetByTitle(string title)
        {
            return context.Exams.First(x => x.Title == title);
        }
        public IEnumerable<Exam> GetAll()
        {
            return context.Exams;
        }
        public void Insert(Exam exam)
        {
            context.Exams.Add(exam);
            context.SaveChanges();
        }

        public void Update(Exam exam, Exam newExam)
        {
            var questions = exam.Questions.ToArray();
            for (var i = 0; i < questions.Count(); i++)
            {
                exam.Remove(questions[i]);
            }
            exam.Insert(newExam.Questions);

            exam.Course = newExam.Course;
            exam.Instructions = newExam.Instructions;
            exam.Title = newExam.Title;

            context.Exams.Update(exam);
            context.SaveChanges();
        }

        public Exam GetById(int id)
        {
            return context.Exams.First(x => x.ExamId == id);
        }
    }
}