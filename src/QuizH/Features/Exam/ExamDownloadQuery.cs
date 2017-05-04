using System.Security.Claims;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamDownloadQuery : IAsyncRequest<ExamDownloadViewModel>
    {
        public int Id { get; set; }
        public ClaimsPrincipal User { get; internal set; }
    }
}