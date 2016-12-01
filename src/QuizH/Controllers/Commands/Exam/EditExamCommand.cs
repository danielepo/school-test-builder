using MediatR;
using QuizH.ViewModels;

namespace QuizH.Controllers.Commands.Exam
{
    public class EditExamCommand : IRequest
    {
        public EditExamViewModel Exam { get; set; }

    }
}