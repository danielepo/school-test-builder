using System.Linq;
using System.Collections.Generic;
using DAL;
using MediatR;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionUpdateQueryHandler : IRequestHandler<QuestionUpdateQuery, QuestionCreationViewModel>
    {
        readonly ISubjectRepository subjects;
        private readonly ICourseRepository courses;
        private readonly IQuestionRepository questions;

        public QuestionUpdateQueryHandler(ISubjectRepository subjects, IQuestionRepository questions, ICourseRepository courses)
        {
            this.subjects = subjects;
            this.questions = questions;
            this.courses = courses;
        }

        public QuestionCreationViewModel Handle(QuestionUpdateQuery message)
        {
            var question = questions.GetById(message.Id);
            if (question == null)
            {
                throw new QuestionNotFoundException();
            }
            return new QuestionCreationViewModel
            {
                Id = question.Id,
                OldId = question.Id,
                Answers = question.Choiches?.Select(x => new AnswerViewModel(x))?.ToList() ?? new List<AnswerViewModel>(),
                Courses = question.Courses?.Select(x => x.Id)?.ToList() ?? new List<int>(),
                Text = question.Text ?? string.Empty,
                SubjectId = question.Subject?.SubjectId ?? 0,
                AvailableCourses = courses.GetAll().Select(x => new CourseViewModel { Id = x.Id, Title = x.Title }).ToList(),
                AvailableSubjects = subjects.GetAll().Select(x => new SubjectViewModel { Id = x.SubjectId, Title = x.Title }).ToList(),
                FreeTextLines = question.Space
            };
        }
    }
}