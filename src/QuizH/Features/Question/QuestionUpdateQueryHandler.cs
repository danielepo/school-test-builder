using System.Linq;
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
            var exam = questions.GetById(message.Id);
            return new QuestionCreationViewModel
            {
                Id = exam.Id,
                OldId = exam.Id,
                Answers = exam.Choiches.Select(x => x.Text).ToList(),
                Courses = exam.Courses?.Select(x=> x.Id).ToList(),
                Text = exam.Text,
                SubjectId = exam.Subject.Id,
                AvailableCourses = courses.GetAll().Select(x => new CourseViewModel { Id = x.Id, Title = x.Title }).ToList(),
                AvailableSubjects = subjects.GetAll().Select(x => new SubjectViewModel { Id = x.Id, Title = x.Title }).ToList()
            };
        }
    }
}