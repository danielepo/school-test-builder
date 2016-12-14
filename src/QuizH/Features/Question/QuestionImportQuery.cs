using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Question
{
    public class QuestionImportQuery: IRequest<QuestionImportViewModel>
    {
    }
}