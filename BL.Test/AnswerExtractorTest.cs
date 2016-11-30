using Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BL.Test
{
    [TestFixture]
    public class AnswerExtractorTest
    {
        AnswerExtractor extractor = new AnswerExtractor();
        private Exam exam;
        private Exam exam2;
        private Exam exam3;
        [SetUp]
        public void SetUp()
        {
            exam = new Exam
            {
                Title = "Titolo",
                Instructions =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
            };
            exam.Insert(new Question("Domanda 1")
            {
                Choiches = new List<Answer>
                {
                    new Answer("risposta 1", 1),
                    new Answer("risposta 2"),
                    new Answer("risposta 3"),
                }
            });
            exam.Insert(new Question("Domanda 2")
            {
                Choiches = new List<Answer>
                {
                    new Answer("risposta 4"),
                    new Answer("risposta 5", 1),
                    new Answer("risposta 6"),
                }
            });
            exam2 = new Exam
            {
                Title = "Titolo",
                Instructions =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
            };
            exam2.Insert(new Question("Domanda 2")
            {
                Choiches = new List<Answer>
                {
                    new Answer("risposta 4"),
                    new Answer("risposta 5", 1),
                    new Answer("risposta 6"),
                }
            });
            exam2.Insert(new Question("Domanda 1")
            {
                Choiches = new List<Answer>
                {
                    new Answer("risposta 2"),
                    new Answer("risposta 3"),
                    new Answer("risposta 1", 1),
                }
            });


            exam3 = new Exam
            {
                Title = "Titolo",
                Instructions =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
            };
            exam3.Insert(new Question("Domanda 1")
            {
                Choiches = new List<Answer>
                {
                    new Answer("risposta 2"),
                    new Answer("risposta 3"),
                    new Answer("risposta 1", 1),
                }
            });
            exam3.Insert(new Question("Domanda 2")
            {
                Choiches = new List<Answer>
                {
                    new Answer("risposta 5", 1),
                    new Answer("risposta 4"),
                    new Answer("risposta 6"),
                }
            });
        }

        [Test]
        public void ExtractAnswers()
        {
            var answers = extractor.Extract(new List<Exam> {exam, exam2, exam3});
            Assert.That(answers.Count, Is.EqualTo(3));
            Assert.That(answers, Is.EquivalentTo(new List<List<string>>
            {
                new List<string> {"1", "2"},
                new List<string> {"2", "3"},
                new List<string> {"3", "1"},
            }));
        }
    }
}