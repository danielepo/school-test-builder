using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Extensions
{
    public static class QuestionExtensions
    {
        public static void Add(this Question question, Answer answer)
        {
            question.Choiches.Add(answer);
        }

        internal static Question Clone(this Question question, Random random)
        {
            return new Question(question.Text)
            {
                Choiches = question.Choiches.Shuffle(random).ToList(),
                Space = question.Space
            };
        }
        public static string Answer(this Question question)
        {
            return question.Choiches.Any(x => x.Points == 1)
                      ? string.Join(",", question.Choiches.Select((c, i) => new { Index = i, Choiche = c })
                                                 .Where(x => x.Choiche.Points == 1)
                                                 .Select(x => x.Index + 1))
                      : "";

        }
    }

}
