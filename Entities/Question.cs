using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int Answer { get { return Choiches.Select((c, i) => new { Index = i, Choiche = c }).First(x => x.Choiche.Points == 1).Index + 1 ; } }
        public ICollection<Answer> Choiches { get; set; }
        public string Text { get; set; }

        public void Add(Answer answer)
        {
            Choiches.Add(answer);
        }

        internal Question Clone()
        {
            return new Question(Text)
            {
                Choiches = Choiches.Shuffle(new Random()).ToList()
            };
        }
    }
}
