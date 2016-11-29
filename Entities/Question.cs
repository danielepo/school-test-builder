using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Extensions;
namespace Entities
{
    public class Question
    {

        public Question(string question)
        {
            Text = question;
            Choiches = new List<Answer>();
        }

        public string Answer
        {
            get
            {
                return Choiches.Any(x => x.Points == 1)
                          ? string.Join(",", Choiches.Select((c, i) => new { Index = i, Choiche = c })
                                                     .Where(x => x.Choiche.Points == 1)
                                                     .Select(x => x.Index + 1))
                          : "";
            }
        }
        public IList<Answer> Choiches { get; set; }
        public int Space { get; set; }
        public string Text { get; set; }

        public void Add(Answer answer)
        {
            Choiches.Add(answer);
        }

        internal Question Clone(Random random)
        {
            return new Question(Text)
            {
                Choiches = Choiches.Shuffle(random).ToList(),
                Space = Space
            };
        }
    }
}
