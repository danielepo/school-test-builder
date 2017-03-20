using DAL;
using MediatR;
using System.Linq;

namespace QuizH.Features.Question
{
    public class QuestionInsertCommandHandler : RequestHandler<QuestionInsertCommand>
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

        protected override void HandleCore(QuestionInsertCommand message)
        {
            var questionVm = message.Question;

            var question = new Entities.Question(questionVm.Text);
            question.Subject = subjects.GetById(questionVm.SubjectId);
            question.Courses = courses.GetAll().Where(x => questionVm.Courses.Contains(x.Id));
            question.Choiches = questionVm.Answers.Select(x => new Entities.Answer(x)).ToList();

            questions.Add(question);
        }
    }
}