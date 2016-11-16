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
    public class QuestionParserTest
    {
        QuestionParser parse = new QuestionParser();
        //[SetUp]
        //public void SetUp()
        //{
        //}
        [TestCase("")]
        [TestCase(null)]
        public void EmptyStringReturnsNotNull(string input)
        {
            IEnumerable<Question> questions = parse.Parse(input);
            Assert.That(questions, Is.Not.Null);
        }
        [Test]
        public void OnlyQuestionReturnsOne()
        {
            string questionText = "text";
            var questions = parse.Parse($"1. {questionText}");
            Assert.That(questions.Count(), Is.EqualTo(1));
            var first = questions.First();
            Assert.That(first.Text, Is.EqualTo(questionText));
        }
        [Test]
        public void TwoQuestionsReturnsTwo()
        {
            var questions = parse.Parse("1. questionText\n2. second");
            Assert.That(questions.Count(), Is.EqualTo(2));
        }
        [Test]
        public void OneQuestionsOneAnswerReturnsOneQuestionWithAnswer()
        {
            var questions = parse.Parse("1. question\na. answer");
            Assert.That(questions.Count(), Is.EqualTo(1));
            var first = questions.First();
            Assert.That(first.Answers.First().Text, Is.EqualTo("answer"));
        }
        [Test]
        public void MultipleReturnsMultiple()
        {
            var questions = parse.Parse("1. question\na. answer\nb. secondo\n2. question2\na. answer2\nb. secondo2\n1. question3\na. answer3\nb. secondo3");
            Assert.That(questions.Count(), Is.EqualTo(3));
        }
    }
}
