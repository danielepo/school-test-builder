using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamUpdateQuery : IRequest<ExamCreationViewModel>
    {
        public string Title;
    }
}