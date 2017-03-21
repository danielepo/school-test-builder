using NUnit.Framework;
using System.Collections.Generic;

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
                    new Answer("text",1),
                    new Answer("text",0),
                },
            };
            Assert.That(question.Answer, Is.EqualTo("1"));
        }
        [Test]
        public void SecondAnswerIsCorrectReturns2()
        {
            var question = new Question("Text")
            {
                Choiches = new List<Answer>
                {
                    new Answer("text",0),
                    new Answer("text",1),
                },
            };
            Assert.That(question.Answer, Is.EqualTo("2"));
        }
        [Test]
        public void TwoCorrectAnswersReturns2Comma3()
        {
            var question = new Question("Text")
            {
                Choiches = new List<Answer>
                {
                    new Answer("text",0),
                    new Answer("text",1),
                    new Answer("text",1),
                },
            };
            Assert.That(question.Answer, Is.EqualTo("2,3"));
        }
        [Test]
        public void QuestionCanHaveAProfessor()
        {
            var prof = new Professor();
            var question = new Question("Test")
            {
                Creator = prof
            };
            Assert.That(question.Creator, Is.EqualTo(prof));
        }
        [Test]
        public void CanBeAssignedASubject()
        {
            var question = new Question("Quante calorie ha un grammo di grassi?");
            question.Subject = new Subject("Alimentazione",0);
            Assert.That(question.Subject.Title, Is.EqualTo("Alimentazione"));
        }

        [Test]
        public void PrintsAnswersInToString()
        {
            var question = new Question("Quante calorie ha un grammo di grassi?")
            {
                Choiches = new List<Answer>()
                {
                    new Answer("20"), new Answer("30"), new Answer("60",1)
                }
            };
            question.Subject = new Subject("Alimentazione", 0);
            Assert.That(question.ToString(), Is.EqualTo("Quante calorie ha un grammo di grassi? [20: 0, 30: 0, 60: 1]"));
        }
    }
}
