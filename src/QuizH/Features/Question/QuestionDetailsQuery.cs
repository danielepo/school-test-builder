using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionDetailsQuery : IAsyncRequest<QuestionDetailsViewModel>
    {
        public int QuestionId;
    }
}