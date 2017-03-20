using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels.Question;
using System.Collections.Generic;
using Entities;

namespace QuizH.Features.Question
{
    public class QuestionListQueryHandler : IRequestHandler<QuestionListQuery, QuestionListViewModel>
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

        public QuestionListViewModel Handle(QuestionListQuery message)
        {
            var randomGenerator = new System.Random();
            return new QuestionListViewModel()
            {
                Questions = questions.GetAll().Select(x => new QuestionViewModel
                {
                    Text = x.Text,
                    Id = x.Id,
                    SubjectId = x.Subject?.Id ?? 0,
                    Courses = x.Courses?.Select(c => c.Id) ?? new List<int>() ,
                }).ToList(),
                Subjects = subjects.GetAll(),
                Courses = courses.GetAll()
            };
        }

    }
}