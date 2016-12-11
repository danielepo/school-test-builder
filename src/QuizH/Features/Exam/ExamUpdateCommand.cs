using MediatR;
using QuizH.ViewModels;

namespace QuizH.Features.Exam
{
    public class ExamUpdateCommand : IRequest
    {
        public EditExamViewModel Exam { get; set; }

    }
}