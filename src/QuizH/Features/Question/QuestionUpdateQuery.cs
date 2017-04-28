using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionUpdateQuery : IAsyncRequest<QuestionCreationViewModel>
    {
        public int Id;
    }
}