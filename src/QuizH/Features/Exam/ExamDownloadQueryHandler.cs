using System;
using DAL;
using MediatR;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamDownloadQueryHandler : IRequestHandler<ExamDownloadQuery, ExamDownloadViewModel>
    {
        private readonly IExamRepository exams;
        
        public ExamDownloadQueryHandler(IExamRepository exams)
        {
            this.exams = exams;
        }

        public ExamDownloadViewModel Handle(ExamDownloadQuery message)
        {
            return new ExamDownloadViewModel();
        }
    }
}