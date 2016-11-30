using System;
using System.Linq;
using DAL;
using Entities;
using MediatR;

namespace QuizH.Controllers
{
    public class InsertExamCommandHandler : RequestHandler<InsertExamCommand>
    {
        readonly ICourseRepository courses;
        readonly IQuestionRepository questions;
        readonly IExamRepository exams;
        //private readonly ExamRepository _context;
        public InsertExamCommandHandler(IExamRepository exams, IQuestionRepository questions, ICourseRepository courses)
        {
            this.exams = exams;
            this.questions = questions;
            this.courses = courses;
        }


        protected override void HandleCore(InsertExamCommand message)
        {

            var examVM = message.Exam;
            var exam = new Exam
            {
                Title = examVM.Title,
                Instructions = examVM.Instructions,
                Course = courses.GetByTitle(examVM.Course),

            };

            exam.Insert(questions.GetAll().Where(x => examVM.Questions.Contains(x.Text)));

            exams.Insert(exam);
        }
    }
}