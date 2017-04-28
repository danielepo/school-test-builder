using BL;
using BL.Interfaces;
using DAL;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace QuizH.Features.Question
{
    public class QuestionImportCommandHandler : AsyncRequestHandler<QuestionImportCommand>
    {
        private IQuestionParser parser;
        private IQuestionRepository repository;
        private ISubjectRepository subjectRepo;

        public QuestionImportCommandHandler(IQuestionParser parser, IQuestionRepository repository, ISubjectRepository subjectRepo)
        {
            this.parser = parser;
            this.repository = repository;
            this.subjectRepo = subjectRepo;
        }

        protected override Task HandleCore(QuestionImportCommand message)
        {
            return Task.Run(() =>
            {
                var vm = message.Questions;
                var questions = parser.Parse(vm.Questions);
                var subject = subjectRepo.GetByTitle(vm.Subject);
                foreach (var q in questions)
                {
                    q.Subject = subject;
                    repository.Add(q);
                }
            });
        }
    }
}