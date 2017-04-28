using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionInsertCommand : IAsyncRequest
    {
        public QuestionCreationViewModel Question { get; set; }
    }
}