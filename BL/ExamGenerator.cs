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
        public ICollection<Exam> Create(Exam exam, int size)
        {
            var exams = new List<Exam>();
            for (int i = 0; i < size; i++)
            {
                var clone = exam.Clone();
                clone.Title += " - " + (i + 1);
                exams.Add(clone);
            }
            return exams;
        }
    }
}
