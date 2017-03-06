using BL;
using BL.Interfaces;
using DAL;
using MediatR;
using System.Linq;
using QuizH.Data;

namespace QuizH.Features.Question
{
    public class QuestionImportCommandHandler : RequestHandler<QuestionImportCommand>
    {
        private IQuestionParser parser;
        private IQuestionRepository repository;
        private ISubjectRepository subjectRepo;
        private readonly EntitiesDbContext _context;

        public QuestionImportCommandHandler(IQuestionParser parser, IQuestionRepository repository, ISubjectRepository subjectRepo, Data.EntitiesDbContext context)
        {
            this.parser = parser;
            this.repository = repository;
            this.subjectRepo = subjectRepo;
            _context = context;
        }

        protected override void HandleCore(QuestionImportCommand message)
        {
            var vm = message.Questions;
            var questions = parser.Parse(vm.Questions);
            //var subject = null;//subjectRepo.GetByTitle(vm.Subject);
            _context.Question.AddRange(questions);
            _context.SaveChanges();
            //foreach (var q in questions)
            //{
            //    q.Subject = null;
            //    repository.Add(q);
            //}
        }
    }
}