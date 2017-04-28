using DAL;
using MediatR;
using QuizH.Features.Question;
using QuizH.ViewModels.Question;
using System.Threading.Tasks;

namespace QuizH.Features.Question
{
    public class QuestionDetailsQueryHandler : IAsyncRequestHandler<QuestionDetailsQuery, QuestionDetailsViewModel>
    {
        private readonly IQuestionRepository question;

        public QuestionDetailsQueryHandler(IQuestionRepository exams)
        {
            this.question = exams;
        }

        public Task<QuestionDetailsViewModel> Handle(QuestionDetailsQuery message)
        {
            return Task.Run(() => QuestionDetailsViewModel.Create(question.GetById(message.QuestionId)));
        }
    }
}