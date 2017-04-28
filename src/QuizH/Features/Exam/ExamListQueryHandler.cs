using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;
using System.Threading.Tasks;

namespace QuizH.Features.Exam
{
    public class ExamListQueryHandler : IAsyncRequestHandler<ExamListQuery, ExamListViewModel>
    {
        readonly ICourseRepository courses;
        readonly IExamRepository exams;

        //private readonly ExamRepository _context;
        public ExamListQueryHandler(IExamRepository exams)
        {
            this.exams = exams;
        }


        public Task<ExamListViewModel> Handle(ExamListQuery message)
        {
            return Task.Run(() =>
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
            });
        }
    }
}