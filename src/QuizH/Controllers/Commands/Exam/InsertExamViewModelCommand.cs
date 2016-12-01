using MediatR;
using QuizH.ViewModels;

namespace QuizH.Controllers.Commands.Exam
{
    public class QueryInsertExamViewModel : IRequest<ExamCreationViewModel>
    {
    }
}