using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public static class QuestionExtensions
    {
        public static string Answer(this Question question)
        {
            return question.Choiches.Any(x => x.Points == 1)
                      ? string.Join(",", question.Choiches.Select((c, i) => new { Index = i, Choiche = c })
                                                 .Where(x => x.Choiche.Points == 1)
                                                 .Select(x => x.Index + 1))
                      : "";

        }
    }
    public class Question
    {
        public int QuestionId;
        public Professor Creator { get; set; }

        public IList<Answer> Choiches { get; set; }

        public int Space { get; set; }

        public string Text { get; set; }

        public virtual Subject Subject { get; set; }
        public Question()
        {
            Text = "";
            Choiches = new List<Answer>();
        }

        public Question(string question)
        {
            Text = question;
            Choiches = new List<Answer>();
        }

        public void Add(Answer answer)
        {
            Choiches.Add(answer);
        }

        public override string ToString()
        {
            return $"{Text} [{string.Join(", ", Choiches)}]";
        }

        internal Question Clone(Random random)
        {
            return new Question(Text)
            {
                Choiches = Choiches.Shuffle(random).ToList(),
                Space = Space
            };
        }
        public IList<Course> Courses { get; set; }
    }
}