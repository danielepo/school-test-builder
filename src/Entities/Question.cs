using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
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

        public override string ToString()
        {
            return $"{Text} [{string.Join(", ", Choiches)}]";
        }

        public IList<Course> Courses { get; set; }
    }
}