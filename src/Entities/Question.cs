using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entities
{
    public static class QuestionExtension
    {
        public static string Answer(this Question question)
        {
                return question.Choiches.Any(x => x.Points == 1)
                          ? string.Join(",", question.Choiches.Select((c, i) => new { Index = i, Choiche = c })
                                                     .Where(x => x.Choiche.Points == 1)
                                                     .Select(x => x.Index + 1))
                          : "";
         
        }
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
    }

    public class Question
    {
        public int QuestionId { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public ICollection<Answer> Choiches { get; set; }

        public int Space { get; set; }

        public string Text { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

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