using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionUpdateCommand : IRequest
    {
        public QuestionCreationViewModel Question { get; set; }

    }
}