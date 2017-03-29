using DAL;
using MediatR;
using QuizH.Features.Question;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionDetailsQueryHandler : IRequestHandler<QuestionDetailsQuery, QuestionDetailsViewModel>
    {
        private readonly IQuestionRepository question;
        
        public QuestionDetailsQueryHandler(IQuestionRepository exams)
        {
            this.question = exams;
        }

        public QuestionDetailsViewModel Handle(QuestionDetailsQuery message)
        {
            return QuestionDetailsViewModel.Create(question.GetById(message.QuestionId));
        }
    }
}