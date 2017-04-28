using DAL;
using MediatR;
using QuizH.ViewModels.Question;
using System.Linq;
using System.Threading.Tasks;

namespace QuizH.Features.Question
{
    public class QuestionImportQueryHandler : IAsyncRequestHandler<QuestionImportQuery, QuestionImportViewModel>
    {
        private ISubjectRepository repository;

        public QuestionImportQueryHandler(ISubjectRepository repository)
        {
            this.repository = repository;
        }

        public Task<QuestionImportViewModel> Handle(QuestionImportQuery message)
        {
            return Task.Run(() => new QuestionImportViewModel()
            {
                AvailableSubjects = repository.GetAll().Select(x => x.Title).ToList(),
            });
        }
    }
}