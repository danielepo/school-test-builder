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
        private List<Question> questions;

        public IEnumerable<Question> Parse(string text)
        {
            questions = new List<Question>();

            if (string.IsNullOrWhiteSpace(text))
                return questions;

            var rows = text.Split('\n');
            foreach (var row in rows)
                ParseRow(row);

            return questions;
        }

        private void ParseRow(string row)
        {
            row = row.Trim();
            if (string.IsNullOrWhiteSpace(row))
                return;
            if (Answer.IsValid(row))
            {
                questions.Last().Add(Answer.FromRow(row));
            }
            else
            {
                questions.Add(new Question(row));
            }
        }
    }
}
