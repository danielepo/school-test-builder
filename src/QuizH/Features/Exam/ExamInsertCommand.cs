using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamInsertCommand : IRequest
    {
        public ExamCreationViewModel Exam { get; set; }
    }
}