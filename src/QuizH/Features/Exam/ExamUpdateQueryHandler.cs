using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;
using System.Collections.Generic;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Exam
{
    public class ExamUpdateQueryHandler : IRequestHandler<ExamUpdateQuery, EditExamViewModel>
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

        public EditExamViewModel Handle(ExamUpdateQuery message)
        {
            var exam = exams.GetByTitle(message.Title);
            return new EditExamViewModel
            {
                OldTitle = exam.Title,
                Title = exam.Title,
                Course = exam.Course.Title,
                Instructions = exam.Instructions,
                Questions = exam.Questions.Select(x => x.Text).ToList(),
                AvailableCourses = courses.GetAll().Select(x => x.Title).ToList(),
                AvailableQuestions = questions.GetAll().Select(x => 
                    new QuestionViewModel
                    {
                        Id = x.Id,
                        Text = x.Text
                    }).ToList()
            };
        }
    }
}