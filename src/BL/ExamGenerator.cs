using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
