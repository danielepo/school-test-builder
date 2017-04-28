using System.Linq;
using DAL;
using MediatR;
using Entities.Extensions;
using System.Threading.Tasks;

namespace QuizH.Features.Exam
{
    public class ExamUpdateCommandHandler : AsyncRequestHandler<ExamUpdateCommand>
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

        protected override Task HandleCore(ExamUpdateCommand message)
        {
            return Task.Run(() =>
            {
                var examVM = message.Exam;
                var newExam = new Entities.Exam
                {
                    Title = examVM.Title,
                    Instructions = examVM.Instructions,
                    Course = courses.GetByTitle(examVM.Course),

                };

                newExam.Insert(questions.GetAll().Where(x => examVM.Questions.Contains(x.QuestionId)));

                var exam = exams.GetById(message.Exam.Id);
                exams.Update(exam, newExam);
            });
        }
    }
}