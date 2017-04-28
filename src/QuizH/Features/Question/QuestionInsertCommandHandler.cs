using DAL;
using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizH.Features.Question
{
    public class QuestionInsertCommandHandler : AsyncRequestHandler<QuestionInsertCommand>
    {
        private readonly ISubjectRepository subjects;
        private readonly ICourseRepository courses;
        private readonly IQuestionRepository questions;


        public QuestionInsertCommandHandler(IQuestionRepository questions, ICourseRepository courses, ISubjectRepository subjects)
        {
            this.questions = questions;
            this.courses = courses;
            this.subjects = subjects;
        }

        protected override Task HandleCore(QuestionInsertCommand message)
        {
            return Task.Run(() =>
            {
                var questionVm = message.Question;

                var question = new Entities.Question(questionVm.Text)
                {
                    Subject = subjects.GetById(questionVm.SubjectId),
                    Courses = courses.GetAll().Where(x => questionVm.Courses.Contains(x.CourseId)).ToList(),
                    Choiches = questionVm.Answers?.Select(x => new Entities.Answer(x.Text, x.IsCorrect ? 1 : 0)).ToList() ?? new List<Entities.Answer>(),
                    Space = questionVm.FreeTextLines
                };
                questions.Add(question);
            });
        }
    }
}