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
       
        [Test]
        public void OnlyQuestionReturnsOne()
        {
            var questions = new List<Question> {
                new Question("Domanda 1"){
                    Answers = new List<Answer>{
                        new Answer("risposta 1"),
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                    }
                },
                new Question("Domanda 2"){
                    Answers = new List<Answer>{
                        new Answer("risposta 1"),
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                    }
                },
                new Question("Domanda 3"){
                    Answers = new List<Answer>{
                        new Answer("risposta 1"),
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                    }
                },
                new Question("Domanda 4"){
                    Answers = new List<Answer>{
                        new Answer("risposta 1"),
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                    }
                },
                new Question("Domanda 5"){
                    Answers = new List<Answer>{
                        new Answer("risposta 1"),
                        new Answer("risposta 2"),
                        new Answer("risposta 3"),
                    }
                },
            };
            generator.Generate(questions);
        }
        
    }
}
