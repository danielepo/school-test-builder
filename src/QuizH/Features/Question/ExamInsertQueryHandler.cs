using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionListQueryHandler : IRequestHandler<QuestionListQuery, QuestionListViewModel>
    {
        readonly IQuestionRepository questions;
        readonly ISubjectRepository subjects;
        //private readonly ExamRepository _context;
        public QuestionListQueryHandler(IQuestionRepository questions, ISubjectRepository subjects)
        {
            this.questions = questions;
            this.subjects = subjects;
        }

        public QuestionListViewModel Handle(QuestionListQuery message)
        {
            return new QuestionListViewModel()
            {
                Questions = questions.GetAll().Select(x => new QuestionViewModel
                {
                    Text = x.Text,
                    Id = x.Id,
                    SubjectId = x.Subject.Id
                }).ToList(),
                Subjects = subjects.GetAll()
            };
        }
        
    }
}