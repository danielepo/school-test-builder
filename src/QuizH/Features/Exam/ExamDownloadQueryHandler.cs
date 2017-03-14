using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamDownloadQueryHandler : IRequestHandler<ExamDownloadQuery, object>
    {
        private readonly IExamRepository exams;
        
        public ExamDownloadQueryHandler(IExamRepository exams)
        {
            this.exams = exams;
        }

        public object Handle(ExamDownloadQuery message)
        {
            return null;
        }
    }
}