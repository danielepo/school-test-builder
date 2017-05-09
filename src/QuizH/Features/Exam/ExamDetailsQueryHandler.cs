using System;
using System.Threading.Tasks;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;

namespace QuizH.Features.Exam
{
    public class ExamDetailsQueryHandler : IAsyncRequestHandler<ExamDetailsQuery, ExamDetailsViewModel>
    {
        private readonly IExamRepository exams;
        
        public ExamDetailsQueryHandler(IExamRepository exams)
        {
            this.exams = exams;
        }
       

        Task<ExamDetailsViewModel> IAsyncRequestHandler<ExamDetailsQuery, ExamDetailsViewModel>.Handle(ExamDetailsQuery message)
        {
            return Task.Run(() => ExamDetailsViewModel.Create(exams.GetById(message.Id)));
        }
    }
}