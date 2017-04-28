using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionImportQuery: IAsyncRequest<QuestionImportViewModel>
    {
    }
}