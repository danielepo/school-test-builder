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
    public class DocumentGeneratorTest
    {
        DocumentGenerator generator = new DocumentGenerator();
        //[SetUp]
        //public void SetUp()
        //{
        //}
        IEnumerable<Question> questions = new List<Question> {
                new Question("Domanda 1"){
                    Answers = new List<Answer>{
                        new Answer("risposta 1"),
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                    }
                },
                new Question("Domanda 2"){
                    Answers = new List<Answer>{
                        new Answer("risposta 4"),
                        new Answer("risposta 5"),
                        new Answer("risposta 6"),
                    }
                },
                new Question("Domanda 3"){
                    Answers = new List<Answer>{
                        new Answer("risposta 7"),
                        new Answer("risposta 8"),
                        new Answer("risposta 9"),
                    }
                },
                new Question("Domanda 4"){
                    Answers = new List<Answer>{
                        new Answer("risposta 10"),
                        new Answer("risposta 11"),
                        new Answer("risposta 12"),
                    }
                },
                new Question("Domanda 5"){
                    Answers = new List<Answer>{
                        new Answer("risposta 13"),
                        new Answer("risposta 14"),
                        new Answer("risposta 15"),
                    }
                },
            };
        [Test]
        public void BasicExamGeneration()
        {
            var exam = new Exam
            {
                Questions = questions,
                Title = "Titolo",
                Instructions = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
            };
            generator.Create(exam);
        }

    }
}
