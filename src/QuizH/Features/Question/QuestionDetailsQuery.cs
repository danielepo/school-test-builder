using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionDetailsQuery : IRequest<QuestionDetailsViewModel>
    {
        public int QuestionId;
    }
}