using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamDownloadQuery : IAsyncRequest<ExamDownloadViewModel>
    {
        public int Id { get; set; }
    }
}