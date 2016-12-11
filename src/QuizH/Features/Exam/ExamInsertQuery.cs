using MediatR;
using QuizH.ViewModels;

namespace QuizH.Features.Exam
{
    public class ExamInsertQuery : IRequest<ExamCreationViewModel>
    {
    }
}