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
        public int AnswerId { get; set; }
        public string Text { get; set; }

        public int Points { get; set; }
        public Answer()
        {
            Text = "";
            Points = 0;
        }
        //why not use a constructor that also have the points?
        public Answer(string value)
        {
            Text = value;
            Points = 0;
        }

        public Answer(string value, int points)
        {
            Text = value;
            Points = points;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Answer))
                return false;

            var that = obj as Answer;
            return this.Equals(that);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Text?.GetHashCode() ?? 0) * 397) ^ Points;
            }
        }

        public override string ToString()
        {
            return $"{Text}: {Points}";
        }

        protected bool Equals(Answer other)
        {
            return string.Equals(Text, other.Text) && Points == other.Points;
        }
    }
}