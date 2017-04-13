using Entities;
using Entities.Extensions;
using System;
using System.Collections.Generic;

namespace BL
{
    public class ExamGenerator
    {
        public IDictionary<int, Exam> Create(Exam exam, int size)
        {
            var exams = new Dictionary<int, Exam>();
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                var clone = exam.Clone(random);
                exams.Add(i + 1, clone);
            }
            return exams;
        }
    }
}
