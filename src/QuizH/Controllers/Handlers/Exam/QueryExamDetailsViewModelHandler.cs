using DAL;
using MediatR;
using QuizH.Controllers.Commands.Exam;
using QuizH.ViewModels;
using System.Linq;

namespace QuizH.Controllers.Handlers.Exam
{
    public class QueryExamDetailsViewModelHandler : IRequestHandler<QueryExamDetailsViewModel, ExamDetailsViewModel>
    {
        private readonly IExamRepository exams;
        
        public QueryExamDetailsViewModelHandler(IExamRepository exams)
        {
            this.exams = exams;
        }

        public ExamDetailsViewModel Handle(QueryExamDetailsViewModel message)
        {
            return ExamDetailsViewModel.Create(exams.GetByTitle(message.Title));
        }
    }
    public class QueryExamEditViewModelHandler : IRequestHandler<QueryExamEditViewModel, EditExamViewModel>
    {
        readonly IExamRepository exams;
        private readonly ICourseRepository courses;
        private readonly IQuestionRepository questions;

        public QueryExamEditViewModelHandler(IExamRepository exams, IQuestionRepository questions, ICourseRepository courses)
        {
            this.exams = exams;
            this.questions = questions;
            this.courses = courses;
        }

        public EditExamViewModel Handle(QueryExamEditViewModel message)
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
                AvailableQuestions = questions.GetAll().Select(x => x.Text).ToList(),
            };
        }
    }

}