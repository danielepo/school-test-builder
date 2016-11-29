using NUnit.Framework;

namespace Entities.Test
{
    [TestFixture]
    public class AnswerTests
    {
        [Test]
        public void AnAnswerHasATextAndPoints()
        {
            var answer = new Answer("irrilevant");
            Assert.That(answer.Text, Is.EqualTo("irrilevant"));
            Assert.That(answer.Points, Is.EqualTo(0));
        }

        [Test]
        public void PointsCanBeAssigned()
        {
            var answer = new Answer("irrilevant",1);
            Assert.That(answer.Points, Is.EqualTo(1));
        }

        [Test]
        public void EmptyAnswerFromEmptyString()
        {
            var answer = Answer.FromRow("");
            Assert.That(answer,Is.EqualTo(new Answer("")));
        }
        [Test]
        public void EmptyAnswerFromPoint()
        {
            var answer = Answer.FromRow(".");
            Assert.That(answer, Is.EqualTo(new Answer("")));
        }
        [Test]
        public void AnswerWithText()
        {
            var parsed = Answer.FromRow(".first:5");
            Assert.That(parsed, Is.EqualTo(new Answer("first",5)));
        }
        [Test]
        public void AnswerWithTextWithWrongPoints()
        {
            var parsed = Answer.FromRow(".first:wrong");
            Assert.That(parsed, Is.EqualTo(new Answer("first",5)));
        }
        [Test]
        public void EmptyAnswerWithWithPoints()
        {
            var parsed = Answer.FromRow(".:5");
            Assert.That(parsed, Is.EqualTo(new Answer("",5)));
        }
    }
}
