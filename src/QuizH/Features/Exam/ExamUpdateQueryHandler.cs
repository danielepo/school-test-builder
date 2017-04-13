using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;
using System.Collections.Generic;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Exam
{
    public class ExamUpdateQueryHandler : IRequestHandler<ExamUpdateQuery, ExamCreationViewModel>
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

        public ExamCreationViewModel Handle(ExamUpdateQuery message)
        {
            var exam = exams.GetByTitle(message.Title);
            return new ExamCreationViewModel
            {
                Id = exam.ExamId,
                Title = exam.Title,
                Course = exam.Course.Title,
                Instructions = exam.Instructions,
                Questions = exam.Questions.Select(x => x.QuestionId).ToList(),
                AvailableCourses = courses.GetAll().Select(x => x.Title).ToList()
            };
        }
    }
}