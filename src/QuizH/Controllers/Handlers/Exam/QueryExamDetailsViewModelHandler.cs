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
    public class QueryExamEditViewModelHandler : IRequestHandler<QueryExamEditViewModel, EditExamViewModel>
    {
        readonly IExamRepository exams;

        public QueryExamEditViewModelHandler(IExamRepository exams)
        {
            this.exams = exams;
        }

        public EditExamViewModel Handle(QueryExamEditViewModel message)
        {s
            message.
            new EditExamViewModel()
            {
                Title = exam.Title,
                Course = exam.Course.Title,
                Instructions = exam.Instructions,
                Questions = exam.Questions.Select(x => x.Text).ToList(),
            };
            return EditExamViewModel.Create(exams.GetByTitle(message.Title));
        }
    }

}