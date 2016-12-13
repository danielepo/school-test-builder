using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;

namespace QuizH.Features.Question
{
    public class QuestionImportQueryHandler : IRequestHandler<QuestionImportQuery, QuestionImportViewModel>
    {
       
        public QuestionImportViewModel Handle(QuestionImportQuery message)
        {
            return new QuestionImportViewModel();
        }
    }
}