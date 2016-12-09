using MediatR;
using QuizH.ViewModels;

namespace QuizH.Features.Exam
{
    public class ExamInsertCommand : IRequest
    {
        public ExamCreationViewModel Exam { get; set; }
    }
}