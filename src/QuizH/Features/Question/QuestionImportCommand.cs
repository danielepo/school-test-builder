using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Question
{
    public class QuestionImportCommand : IRequest
    {
        public QuestionImportViewModel Questions { get; set; }
    }
}