using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var answer = new Answer("irrilevant") { Points = 1 };
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
            var answer = Answer.FromRow(".first:5");
            Assert.That(answer, Is.EqualTo(new Answer("first") {Points = 5}));
        }
    }
}
