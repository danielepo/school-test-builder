using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionInsertCommand : IRequest
    {
        public QuestionCreationViewModel Question { get; set; }
    }
}