using MediatR;
using QuizH.ViewModels;

namespace QuizH.Controllers
{
    public class QueryExamDetailsViewModel : IRequest<ExamListViewModel>
    {
    }
}