using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels.Question;
using System.Collections.Generic;
using Entities;
using System.Threading.Tasks;

namespace QuizH.Features.Question
{
    public class QuestionListQueryHandler : IAsyncRequestHandler<QuestionListQuery, QuestionListViewModel>
    {
        readonly IQuestionRepository questions;
        readonly ISubjectRepository subjects;
        readonly ICourseRepository courses;
        //private readonly ExamRepository _context;
        public QuestionListQueryHandler(IQuestionRepository questions, ISubjectRepository subjects,
            ICourseRepository courses)
        {
            this.questions = questions;
            this.subjects = subjects;
            this.courses = courses;
        }

        public Task<QuestionListViewModel> Handle(QuestionListQuery message)
        {
            return Task.Run(() => new QuestionListViewModel()
            {
                Questions = questions.GetAll().Select(x => new QuestionViewModel
                {
                    Text = x.Text,
                    Id = x.QuestionId,
                    SubjectId = x.Subject?.SubjectId ?? 0,
                    Courses = x.Courses?.Select(c => c.CourseId) ?? new List<int>(),
                }).ToList(),
                Subjects = subjects.GetAll(),
                Courses = courses.GetAll()
            });
        }

    }
}