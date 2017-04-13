using Entities;
using Entities.Extensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BL.Test
{
    [TestFixture]
    public class ExamsGeneratorTest
    {
        ExamGenerator generator = new ExamGenerator();
        private Exam exam;
        [SetUp]
        public void SetUp()
        {
            exam = new Exam();
            exam.Insert(new Question("Domanda 1"){
                Choiches = new List<Answer>{
                    new Answer("risposta 1"),
                    new Answer("risposta 2"),
                    new Answer("risposta 3"),
                }
            });
            exam.Insert(new Question("Domanda 2"){
                Choiches = new List<Answer>{
                    new Answer("risposta 4"),
                    new Answer("risposta 5"),
                    new Answer("risposta 6"),
                }
            });
            exam.Insert(new Question("Domanda 3"){
                Choiches = new List<Answer>{
                    new Answer("risposta 7"),
                    new Answer("risposta 8"),
                    new Answer("risposta 9"),
                }
            });
            exam.Insert(new Question("Domanda 4"){
                Choiches = new List<Answer>{
                    new Answer("risposta 10"),
                    new Answer("risposta 11"),
                    new Answer("risposta 12"),
                }
            });
            exam.Insert(new Question("Domanda 5"){
                Choiches = new List<Answer>{
                    new Answer("risposta 13"),
                    new Answer("risposta 14"),
                    new Answer("risposta 15"),
                }
            });
        }

        [Test]
        public void RandomizeExams()
        {
            var exams = generator.Create(exam, 50);
            Assert.That(exams.Count, Is.EqualTo(50));
            Assert.IsTrue(IsRandomAt(0, exams));
            Assert.IsTrue(IsRandomAt(1, exams));
            Assert.IsTrue(IsRandomAt(2, exams));
            Assert.IsTrue(IsRandomAt(3, exams));
            Assert.IsTrue(IsRandomAt(4, exams));
        }

        [Test]
        public void ChangeTitle()
        {
            var exams = generator.Create(exam, 3);
            Assert.That(exams.ElementAt(0).Key, Is.EqualTo(1));
            Assert.That(exams.ElementAt(1).Key, Is.EqualTo(2));
            Assert.That(exams.ElementAt(2).Key, Is.EqualTo(3));
        }

        private bool IsRandomAt(int index, IDictionary<int, Exam> exams)
        {
            return exams.Select(x => x.Value.Questions.ElementAt(index)).Any(x => !x.Text.EndsWith((index + 1).ToString()));
        }
    }
}
