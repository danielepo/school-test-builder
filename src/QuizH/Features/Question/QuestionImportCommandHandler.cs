using System.Linq;
using DAL;
using MediatR;
using BL;
using BL.Interfaces;

namespace QuizH.Features.Question
{
    public class QuestionImportCommandHandler : RequestHandler<QuestionImportCommand>
    {
        private IQuestionParser parser;
        private IQuestionRepository repository;

        public QuestionImportCommandHandler(IQuestionParser parser, IQuestionRepository repository)
        {
            this.parser = parser;
            this.repository = repository;
        }

        protected override void HandleCore(QuestionImportCommand message)
        {
            var questions = parser.Parse(message.Questions.Questions);
            foreach (var q in questions)
                repository.Add(q);
        }
    }
}