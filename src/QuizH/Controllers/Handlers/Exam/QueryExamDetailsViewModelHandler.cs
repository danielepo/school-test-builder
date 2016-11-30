using DAL;
using MediatR;
using QuizH.Controllers.Commands.Exam;
using QuizH.ViewModels;

namespace QuizH.Controllers.Handlers.Exam
{
    public class QueryExamDetailsViewModelHandler : IRequestHandler<QueryExamDetailsViewModel, ExamDetailsViewModel>
    {
        readonly IExamRepository exams;

        public QueryExamDetailsViewModelHandler(IExamRepository exams)
        {
            this.exams = exams;
        }

        public ExamDetailsViewModel Handle(QueryExamDetailsViewModel message)
        {
            return ExamDetailsViewModel.Create(exams.GetByTitle(message.Title));
        }
    }
}