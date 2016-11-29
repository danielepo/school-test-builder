using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Answer
    {
        //why not use a constructor that also have the points?
        public Answer(string value)
        {
            Text = value;
        }

        public string Text { get; private set; }
        public int Points { get; set; }
        // should be part of the answer or part of a validator/parser
        // there's nothing about the answer here
        public static bool IsValid(string row)
        {
            var start = row.IndexOf('.');
            if (start < 0)
                return false;
            var prefix = row.Substring(0, start);
            int ignored;
            return int.TryParse(prefix, out ignored);
        }

        // why return always a good answer?
        public static Answer FromRow(string row)
        {
            var start = row.IndexOf('.');
            var end = row.LastIndexOf(':');
            int points = 0;
            if (end < 0)
                end = row.Length;
            else
            {
                var suffix = row.Substring(end + 1);
                int.TryParse(suffix, out points);
            }
            end -= start + 1;
            var value = row.Substring(start + 1, end).Trim();
            return new Answer(value)
            {
                Points = points
            };
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Answer))
                return false;

            var that = obj as Answer;
            return Points == that.Points &&
                   Text == that.Text;
        }

        protected bool Equals(Answer other)
        {
            return string.Equals(Text, other.Text) && Points == other.Points;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Text?.GetHashCode() ?? 0)*397) ^ Points;
            }
        }
    }
}