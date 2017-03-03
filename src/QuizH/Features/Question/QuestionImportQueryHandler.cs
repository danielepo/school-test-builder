using DAL;
using MediatR;
using QuizH.ViewModels.Question;
using System.Linq;

namespace QuizH.Features.Question
{
    public class QuestionImportQueryHandler : IRequestHandler<QuestionImportQuery, QuestionImportViewModel>
    {
        private ISubjectRepository repository;

        public QuestionImportQueryHandler(ISubjectRepository repository)
        {
            this.repository = repository;
        }

        public QuestionImportViewModel Handle(QuestionImportQuery message)
        {
            return new QuestionImportViewModel()
            {
                AvailableSubjects = repository.GetAll().Select(x => x.Title).ToList(),
            };
        }
    }
}