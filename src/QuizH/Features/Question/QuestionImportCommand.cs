using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionImportCommand : IAsyncRequest
    {
        public QuestionImportViewModel Questions { get; set; }
    }
}