using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int? ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public List<Answer> Choiches { get; set; }
        public List<Course> Courses { get; set; }
        public int Space { get; set; }

        public string Text { get; set; }

        public virtual int? SubjectId { get; set; }
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

    }
}