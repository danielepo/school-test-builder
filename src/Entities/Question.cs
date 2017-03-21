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
            return question.Choices.Any(x => x.Points == 1)
                      ? string.Join(",", question.Choices.Select((c, i) => new { Index = i, Choiche = c })
                                                 .Where(x => x.Choiche.Points == 1)
                                                 .Select(x => x.Index + 1))
                      : "";

        }
    }
    public class Question
    {
        public int Id;
        public Professor Creator { get; set; }

        public IList<Answer> Choices { get; set; }

        public int Space { get; set; }

        public string Text { get; set; }

        public virtual Subject Subject { get; set; }

        public Question(string question)
        {
            Text = question;
            Choices = new List<Answer>();
        }

        public void Add(Answer answer)
        {
            Choices.Add(answer);
        }

        public override string ToString()
        {
            return $"{Text} [{string.Join(", ", Choices)}]";
        }

        internal Question Clone(Random random)
        {
            return new Question(Text)
            {
                Choices = Choices.Shuffle(random).ToList(),
                Space = Space
            };
        }
        public IEnumerable<Course> Courses{get;set;}
    }
}