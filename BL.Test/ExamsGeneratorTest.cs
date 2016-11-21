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
    public class ExamsGeneratorTest
    {
        ExamGenerator generator = new ExamGenerator();
        
        Exam exam = new Exam
        {
            Questions = new List<Question> {
                new Question("Domanda 1"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 1"),
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                    }
                },
                new Question("Domanda 2"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 4"),
                        new Answer("risposta 5"),
                        new Answer("risposta 6"),
                    }
                },
                new Question("Domanda 3"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 7"),
                        new Answer("risposta 8"),
                        new Answer("risposta 9"),
                    }
                },
                new Question("Domanda 4"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 10"),
                        new Answer("risposta 11"),
                        new Answer("risposta 12"),
                    }
                },
                new Question("Domanda 5"){
                    Choiches = new List<Answer>{
                        new Answer("risposta 13"),
                        new Answer("risposta 14"),
                        new Answer("risposta 15"),
                    }
                },
            },
            Title = "Titolo",
            Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
        };

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
            Assert.That(exams.ElementAt(0).Type, Is.EqualTo(1));
            Assert.That(exams.ElementAt(1).Type, Is.EqualTo(2));
            Assert.That(exams.ElementAt(2).Type, Is.EqualTo(3));
        }

        private bool IsRandomAt(int index, ICollection<Exam> exams)
        {
            return exams.Select(x => x.Questions.ElementAt(index)).Any(x => !x.Text.EndsWith((index + 1).ToString()));
        }
    }
}
