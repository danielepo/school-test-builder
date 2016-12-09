using MediatR;
using QuizH.ViewModels;

namespace QuizH.Features.Exam
{
    public class ExamDetailsQuery : IRequest<ExamDetailsViewModel>
    {
        public string Title;
    }
}