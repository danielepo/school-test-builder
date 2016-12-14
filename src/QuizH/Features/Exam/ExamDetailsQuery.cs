using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamDetailsQuery : IRequest<ExamDetailsViewModel>
    {
        public string Title;
    }
}