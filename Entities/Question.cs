using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Question
    {

        public Question(string question)
        {
            Text = question;
            Answers = new List<Answer>();
        }

        public ICollection<Answer> Answers { get; set; }
        public string Text { get; set; }

        public void Add(Answer answer)
        {
            Answers.Add(answer);
        }
    }
}
