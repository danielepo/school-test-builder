using QuizH.ViewModels.Question;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace QuizH.ViewModels.Question
{
    public class QuestionDetailsViewModel
    {
        public string Text { get; set; }
        public IEnumerable<AnswerViewModel> Options { get; set; }
        public IEnumerable<string> Courses { get; private set; }
        public string Subject { get; private set; }

        public static QuestionDetailsViewModel Create(Entities.Question question)
        {
            return new QuestionDetailsViewModel
            {
                Text = question.Text,
                Courses = question.Courses?.Select(c=> c.Title) ?? new List<string>(),
                Options = question.Choiches?.Select(c=> new AnswerViewModel(c))?? new List<AnswerViewModel>(),
                Subject = question.Subject?.Title
            };
        }

    }
}