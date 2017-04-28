using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionUpdateCommand : IAsyncRequest
    {
        public QuestionCreationViewModel Question { get; set; }

    }
}