using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Test
{
    [TestFixture]
    public class QuestionTests
    {
        [Test]
        public void FirstAnswerIsCorrectReturns1()
        {
            var question = new Question("Text")
            {
                Choiches = new List<Answer>
                {
                    new Answer("text") { Points = 1},
                    new Answer("text") { Points = 0},
                },
            };
            Assert.That(question.Answer, Is.EqualTo(1));
        }
        [Test]
        public void SecondAnswerIsCorrectReturns2()
        {
            var question = new Question("Text")
            {
                Choiches = new List<Answer>
                {
                    new Answer("text") { Points = 0},
                    new Answer("text") { Points = 1},
                },
            };
            Assert.That(question.Answer, Is.EqualTo(2));
        }
    }
}
