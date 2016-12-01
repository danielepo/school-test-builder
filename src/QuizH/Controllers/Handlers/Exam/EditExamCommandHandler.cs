using System.Linq;
using DAL;
using MediatR;
using QuizH.Controllers.Commands.Exam;

namespace QuizH.Controllers.Handlers.Exam
{
    public class EditExamCommandHandler : RequestHandler<EditExamCommand>
    {
        readonly ICourseRepository courses;
        readonly IQuestionRepository questions;
        readonly IExamRepository exams;
        //private readonly ExamRepository _context;
        public EditExamCommandHandler(IExamRepository exams, IQuestionRepository questions, ICourseRepository courses)
        {
            this.exams = exams;
            this.questions = questions;
            this.courses = courses;
        }

        protected override void HandleCore(EditExamCommand message)
        {
            var examVM = message.Exam;
            var newExam = new Entities.Exam
            {
                Title = examVM.Title,
                Instructions = examVM.Instructions,
                Course = courses.GetByTitle(examVM.Course),

            };

            newExam.Insert(questions.GetAll().Where(x => examVM.Questions.Contains(x.Text)));

            var exam = exams.GetByTitle(message.Exam.OldTitle);
            exams.Update(exam, newExam);
        }
    }
}