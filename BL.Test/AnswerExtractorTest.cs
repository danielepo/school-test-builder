using Entities;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Test
{
    [TestFixture]
    public class AnswerExtractorTest
    {
        AnswerExtractor extractor = new AnswerExtractor();

        Exam exam = new Exam
        {
            Questions = new List<Question> {
                new Question("Domanda 1"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 1"){Points=1 },
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                    }
                },
                new Question("Domanda 2"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 4"),
                        new Answer("risposta 5"){Points=1 },
                        new Answer("risposta 6"),
                    }
                },
            },
            Title = "Titolo",
            Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
        };
        Exam exam2 = new Exam
        {
            Questions = new List<Question> {

                new Question("Domanda 2"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 4"),
                        new Answer("risposta 5"){Points=1 },
                        new Answer("risposta 6"),
                    }
                },
                new Question("Domanda 1"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                        new Answer("risposta 1"){Points=1 },
                    }
                },
            },
            Title = "Titolo",
            Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
        };
        Exam exam3 = new Exam
        {
            Questions = new List<Question> {
                new Question("Domanda 1"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                        new Answer("risposta 1"){Points=1 },
                    }
                },
                new Question("Domanda 2"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 5"){Points=1 },
                        new Answer("risposta 4"),
                        new Answer("risposta 6"),
                    }
                },
            },
            Title = "Titolo",
            Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
        };
        [Test]
        public void ExtractAnswers()
        {
            var answers = extractor.Extract(new List<Exam> { exam, exam2, exam3 });
            Assert.That(answers.Count, Is.EqualTo(3));
            Assert.That(answers, Is.EquivalentTo(new List<List<int>> {
                new List<int>{1, 2},
                new List<int>{2, 3},
                new List<int>{3, 1},
            }));
        }
    }
}
