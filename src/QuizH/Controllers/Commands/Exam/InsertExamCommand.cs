using MediatR;
using QuizH.ViewModels;

namespace QuizH.Controllers
{
    public class InsertExamCommand : IRequest
    {
        public ExamCreationViewModel Exam { get; set; }
    }
}