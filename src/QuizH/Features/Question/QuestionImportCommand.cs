using MediatR;
using QuizH.ViewModels;

namespace QuizH.Features.Question
{
    public class QuestionImportCommand : IRequest
    {
        public QuestionImportViewModel Questions { get; set; }
    }
}