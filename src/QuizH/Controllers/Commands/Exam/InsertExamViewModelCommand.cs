using MediatR;
using QuizH.ViewModels;

namespace QuizH.Controllers
{
    public class QueryInsertExamViewModel : IRequest<ExamCreationViewModel>
    {
    }
}