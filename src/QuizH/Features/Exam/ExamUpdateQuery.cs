using MediatR;
using QuizH.ViewModels;

namespace QuizH.Features.Exam
{
    public class ExamUpdateQuery : IRequest<EditExamViewModel>
    {
        public string Title;
    }
}