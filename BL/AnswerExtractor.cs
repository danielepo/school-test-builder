﻿using DocumentFormat.OpenXml;
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
    public class AnswerExtractor
    {
        public IEnumerable<IEnumerable<string>> Extract(IEnumerable<Exam> exams)
        {
            return exams.Select(e => e.Questions.Select(q => q.Answer).ToList()).ToList();
        }
        public IEnumerable<IEnumerable<string>> Extract(IEnumerable<Question> questions)
        {
            return new List<IEnumerable<string>>{ questions.Select(q => q.Answer).ToList() };
        }
    }
}
