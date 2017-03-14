using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuizH.Features.Exam
{
    public class ExamDownloadQuery : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
}