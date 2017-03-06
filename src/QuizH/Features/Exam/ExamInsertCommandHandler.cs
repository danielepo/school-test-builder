using DAL;
using MediatR;
using System.Linq;
using Entities;
using QuizH.Data;

namespace QuizH.Features.Exam
{
    public class ExamInsertCommandHandler : RequestHandler<ExamInsertCommand>
    {
        private readonly ICourseRepository courses;
        private readonly EntitiesDbContext _context;
        private readonly IQuestionRepository questions;
        private readonly IExamRepository exams;

        public ExamInsertCommandHandler(IExamRepository exams, IQuestionRepository questions, ICourseRepository courses, Data.EntitiesDbContext context)
        {
            this.exams = exams;
            this.questions = questions;
            this.courses = courses;
            _context = context;
        }

        protected override void HandleCore(ExamInsertCommand message)
        {
            var examVM = message.Exam;

            var exam = new Entities.Exam
            {

                Title = examVM.Title,
                Instructions = examVM.Instructions,
                Course = courses.GetByTitle(examVM.Course),
            };

            exam.Insert(questions.GetAll().Where(x => examVM.Questions.Contains(x.QuestionId)));
            _context.Exam.Add(exam);
            _context.SaveChanges();
            exams.Insert(exam);
        }
    }
}