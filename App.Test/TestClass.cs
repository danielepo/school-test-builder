using BL;
using Entities;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Test
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            var parser = new QuestionParser();
            var generator = new ExamGenerator();
            var documenter = new DocumentGenerator();
            var questions = parser.Parse(test);
            var exam = new Exam()
            {
                Title = "Educazione alimentare",
                Questions = questions,
                Instructions = "Leggere attentamente le domande e fare una X su una o più risposte per indicare quelle corrette. Oppure completa le parti mancanti dove opportuno."
            };
            var exams = generator.Create(exam, 20);
            foreach (var e in exams)
                documenter.Create(e);

            var answers = new AnswerExtractor().Extract(exams);
            new AnswerSheetWriter().Create(answers);
        }
        [Test]
        public void Rader()
        {
            var parser = new QuestionParser();
            var generator = new ExamGenerator();
            //var documenter = new DocumentGenerator();
            var documenter = new DocumentReader();
            var questions = parser.Parse(test);
            var exam = new Exam()
            {
                Title = "Educazione alimentare",
                Questions = questions,
                Instructions = "Leggere attentamente le domande e fare una X su una o più risposte per indicare quelle corrette. Oppure completa le parti mancanti dove opportuno."
            };
            //var exams = generator.Create(exam, 1);
            //foreach (var e in exams)
            var q = documenter.Read(17);
            Match(exam.Questions, q);
            var answers = new AnswerExtractor().Extract(q);
            new AnswerSheetWriter().Create(answers);
        }

        private void Match(IEnumerable<Question> from, ICollection<Question> to)
        {
            foreach (var q in from)
            {
                var toQ = to.Single(x => x.Text == q.Text);
                foreach (var a in toQ.Choiches)
                {
                    a.Points = q.Choiches.First(x => x.Text == a.Text).Points;
                }
            }
        }

        string test = @"";
    }
}
