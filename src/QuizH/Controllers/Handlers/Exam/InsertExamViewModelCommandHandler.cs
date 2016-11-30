using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;

namespace QuizH.Controllers
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
    public class QueryExamDetailsViewModelHandler : IRequestHandler<QueryExamDetailsViewModel, ExamListViewModel>
    {
        readonly ICourseRepository courses;
        readonly IExamRepository exams;

        //private readonly ExamRepository _context;
        public QueryExamDetailsViewModelHandler(IExamRepository exams)
        {
            this.exams = exams;
        }


        public ExamListViewModel Handle(QueryExamDetailsViewModel message)
        {
            return new ExamListViewModel
            {
                Exams = exams.GetAll().Select(x => new ExamDetailsViewModel
                {
                    Title = x.Title,
                    Instructions = x.Instructions,
                    Course = x.Course.Title
                })
            };
        }
    }
}