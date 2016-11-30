using MediatR;
using QuizH.ViewModels;

namespace QuizH.Controllers.Commands.Exam
{
    public class InsertExamCommand : IRequest
    {
        public ExamCreationViewModel Exam { get; set; }
    }
}