using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;
using System.Collections.Generic;
using QuizH.ViewModels.Question;
using System.Threading.Tasks;

namespace QuizH.Features.Exam
{
    public class ExamUpdateQueryHandler : IAsyncRequestHandler<ExamUpdateQuery, ExamCreationViewModel>
    {
        readonly IExamRepository exams;
        private readonly ICourseRepository courses;
        private readonly IQuestionRepository questions;

        public ExamUpdateQueryHandler(IExamRepository exams, IQuestionRepository questions, ICourseRepository courses)
        {
            this.exams = exams;
            this.questions = questions;
            this.courses = courses;
        }

        public Task<ExamCreationViewModel> Handle(ExamUpdateQuery message)
        {
            return Task.Run(() =>
            {
                var exam = exams.GetById(message.Id);
                return new ExamCreationViewModel
                {
                    Id = exam.ExamId,
                    Title = exam.Title,
                    Course = exam.Course.Title,
                    Instructions = exam.Instructions,
                    Questions = exam.Questions.Select(x => x.QuestionId).ToList(),
                    AvailableCourses = courses.GetAll().Select(x => x.Title).ToList()
                };
            });
        }
    }
}