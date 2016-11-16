using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class QuestionParser
    {
        public IEnumerable<Question> Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new List<Question>();

            var questions = new List<Question>();
            var rows = text.Split('\n');
            foreach (var row in rows)
            {
                var firstPoint = row.IndexOf('.');
                var prefix = row.Substring(0, firstPoint);
                var value = row.Substring(firstPoint + 1).Trim();
                int ignored;
                if (int.TryParse(prefix, out ignored))
                {
                    questions.Add(new Question(value));
                }
                else
                {
                    questions.Last().Answers.Add(new Answer(value));
                }
            }

            return questions;
        }
    }
}
