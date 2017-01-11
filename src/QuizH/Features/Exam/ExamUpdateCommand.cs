using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamUpdateCommand : IRequest
    {
        public ExamCreationViewModel Exam { get; set; }

    }
}