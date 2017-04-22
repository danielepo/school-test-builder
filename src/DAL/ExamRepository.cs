using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DAL
{
    public class ExamRepository : IExamRepository
    {
        private readonly EntityDbContext context;

        private IQueryable<Exam> AllExams
        {
            get
            {
                return context.Exams
                    .Include(e => e.Questions)
                    .ThenInclude(q => q.Choiches);
            }
        }

        public ExamRepository(EntityDbContext context)
        {
            this.context = context;
        }

        public Exam GetByTitle(string title)
        {
            return AllExams.First(x => x.Title == title);
        }

        public IEnumerable<Exam> GetAll()
        {
            return AllExams;
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
            return AllExams.First(x => x.ExamId == id);
        }
    }
}