using DAL;
using Entities.Extensions;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace QuizH.Features.Exam
{
    public class ExamInsertCommandHandler : AsyncRequestHandler<ExamInsertCommand>
    {
        private readonly ICourseRepository courses;
        private readonly IQuestionRepository questions;
        private readonly IExamRepository exams;

        public ExamInsertCommandHandler(IExamRepository exams, IQuestionRepository questions, ICourseRepository courses)
        {
            this.exams = exams;
            this.questions = questions;
            this.courses = courses;
        }

        protected override Task HandleCore(ExamInsertCommand message)
        {
            var examVM = message.Exam;

            var exam = new Entities.Exam
            {

                Title = examVM.Title,
                Instructions = examVM.Instructions,
                Course = courses.GetByTitle(examVM.Course),
            };
            return Task.Run(() =>
            {
                exam.Insert(questions.GetAll().Where(x => examVM.Questions.Contains(x.QuestionId)));
                exams.Insert(exam);
            });
        }
    }
}