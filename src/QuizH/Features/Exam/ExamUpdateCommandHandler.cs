using System.Linq;
using DAL;
using MediatR;

namespace QuizH.Features.Exam
{
    public class ExamUpdateCommandHandler : RequestHandler<ExamUpdateCommand>
    {
        readonly ICourseRepository courses;
        readonly IQuestionRepository questions;
        readonly IExamRepository exams;
        //private readonly ExamRepository _context;
        public ExamUpdateCommandHandler(IExamRepository exams, IQuestionRepository questions, ICourseRepository courses)
        {
            this.exams = exams;
            this.questions = questions;
            this.courses = courses;
        }

        protected override void HandleCore(ExamUpdateCommand message)
        {
            var examVM = message.Exam;
            var newExam = new Entities.Exam
            {
                Title = examVM.Title,
                Instructions = examVM.Instructions,
                Course = courses.GetByTitle(examVM.Course),

            };

            newExam.Insert(questions.GetAll().Where(x => examVM.Questions.Contains(x.Id)));

            var exam = exams.GetById(message.Exam.Id);
            exams.Update(exam, newExam);
        }
    }
}