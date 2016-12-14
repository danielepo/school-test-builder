using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

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