﻿using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Extensions;

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
            exam.ExamId = Exams.Count() + 1;
            Exams.Add(exam);
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
        }

        public Exam GetById(int id)
        {
            return Exams.First(x => x.ExamId == id);
        }
    }
}