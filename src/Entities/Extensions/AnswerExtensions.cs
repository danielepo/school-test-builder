using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Extensions
{
    public static class AnswerExtensions
    {
        public static bool IsValid(string row)
        {
            var start = row.IndexOf('.');
            if (start < 0)
                return false;
            var prefix = row.Substring(0, start);
            return int.TryParse(prefix, out int ignored);
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
            return new Answer(value, points);
        }

    }
}
