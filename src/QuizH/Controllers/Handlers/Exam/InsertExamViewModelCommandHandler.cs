using System.Linq;
using DAL;
using MediatR;
using QuizH.Controllers.Commands.Exam;
using QuizH.ViewModels;

namespace QuizH.Controllers.Handlers.Exam
{
    public class QueryInsertExamViewModelHandler : IRequestHandler<QueryInsertExamViewModel, ExamCreationViewModel>
    {
        readonly ICourseRepository courses;
        readonly IQuestionRepository questions;
        //private readonly ExamRepository _context;
        public QueryInsertExamViewModelHandler(IQuestionRepository questions, ICourseRepository courses)
        {
            this.questions = questions;
            this.courses = courses;
        }


        public ExamCreationViewModel Handle(QueryInsertExamViewModel message)
        {
            return new ExamCreationViewModel
            {
                AvailableCourses = courses.GetAll().Select(x => x.Title).ToList(),
                AvailableQuestions = questions.GetAll().Select(x => x.Text).ToList()
            };
        }
    }
}