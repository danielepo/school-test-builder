using System.Linq;
using DAL;
using MediatR;
using QuizH.Controllers.Commands.Exam;
using QuizH.ViewModels;

namespace QuizH.Controllers.Handlers.Exam
{
    public class QueryExamListViewModelHandler : IRequestHandler<QueryExamListViewModel, ExamListViewModel>
    {
        readonly ICourseRepository courses;
        readonly IExamRepository exams;

        //private readonly ExamRepository _context;
        public QueryExamListViewModelHandler(IExamRepository exams)
        {
            this.exams = exams;
        }


        public ExamListViewModel Handle(QueryExamListViewModel message)
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