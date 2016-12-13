using MediatR;
using QuizH.ViewModels;

namespace QuizH.Features.Question
{
    public class QuestionImportQuery: IRequest<QuestionImportViewModel>
    {
    }
}