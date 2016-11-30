using MediatR;
using QuizH.ViewModels;

namespace QuizH.Controllers.Commands.Exam
{
    public class QueryExamDetailsViewModel : IRequest<ExamDetailsViewModel>
    {
        public string Title;
    }
}