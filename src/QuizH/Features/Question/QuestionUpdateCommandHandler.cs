using System.Linq;
using System.Collections.Generic;
using DAL;
using MediatR;
using System.Threading.Tasks;

namespace QuizH.Features.Question
{
    public class QuestionUpdateCommandHandler : AsyncRequestHandler<QuestionUpdateCommand>
    {
        readonly ICourseRepository courses;
        readonly IQuestionRepository questions;
        readonly ISubjectRepository subjects;

        public QuestionUpdateCommandHandler(IQuestionRepository questions,
            ICourseRepository courses, ISubjectRepository subjects)
        {
            this.questions = questions;
            this.courses = courses;
            this.subjects = subjects;
        }

        protected override Task HandleCore(QuestionUpdateCommand message)
        {
            return Task.Run(() =>
            {
                var qVm = message.Question;
                var newQuestion = new Entities.Question(qVm.Text)
                {
                    Subject = subjects.GetById(qVm.SubjectId),
                    Choiches = qVm.Answers?.Select(x => new Entities.Answer(x.Text, x.IsCorrect ? 1 : 0))?.ToList() ?? new List<Entities.Answer>(),
                    Courses = courses.GetAll().Where(x => qVm.Courses?.Contains(x.CourseId) ?? false).ToList(),
                    Space = qVm.FreeTextLines
                };

                var oldQuestion = questions.GetById(qVm.OldId);
                questions.Update(oldQuestion, newQuestion);
            });
        }
    }
}