using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamUpdateCommand : IAsyncRequest
    {
        public ExamCreationViewModel Exam { get; set; }

    }
}