using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamDetailsQueryHandler : IRequestHandler<ExamDetailsQuery, ExamDetailsViewModel>
    {
        private readonly IExamRepository exams;
        
        public ExamDetailsQueryHandler(IExamRepository exams)
        {
            this.exams = exams;
        }

        public ExamDetailsViewModel Handle(ExamDetailsQuery message)
        {
            return ExamDetailsViewModel.Create(exams.GetByTitle(message.Title));
        }
    }
}