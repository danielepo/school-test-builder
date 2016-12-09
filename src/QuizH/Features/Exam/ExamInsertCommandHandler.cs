using System.Linq;
using DAL;
using MediatR;

namespace QuizH.Features.Exam
{
    public class ExamInsertCommandHandler : RequestHandler<ExamInsertCommand>
    {
        readonly ICourseRepository courses;
        readonly IQuestionRepository questions;
        readonly IExamRepository exams;
        //private readonly ExamRepository _context;
        public ExamInsertCommandHandler(IExamRepository exams, IQuestionRepository questions, ICourseRepository courses)
        {
            this.exams = exams;
            this.questions = questions;
            this.courses = courses;
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

            exam.Insert(questions.GetAll().Where(x => examVM.Questions.Contains(x.Text)));

            exams.Insert(exam);
        }
    }
}