﻿using Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
            var questions = parse.Parse($"{questionText}");
            Assert.That(questions.Count(), Is.EqualTo(1));
            var first = questions.First();
            Assert.That(first.Text, Is.EqualTo(questionText));
        }
        [Test]
        public void TwoQuestionsReturnsTwo()
        {
            var questions = parse.Parse("questionText\nsecond");
            Assert.That(questions.Count(), Is.EqualTo(2));
        }
        [Test]
        public void OneQuestionsOneAnswerReturnsOneQuestionWithAnswer()
        {
            var questions = parse.Parse("question\n1. answer");
            Assert.That(questions.Count(), Is.EqualTo(1));
            var first = questions.First();
            Assert.That(first.Choiches.First().Text, Is.EqualTo("answer"));
        }
        [Test]
        public void AnswerWithPointsParsesCorrectlyPoints()
        {
            var questions = parse.Parse("question\n1. answer:1\n2. wrong:0");
            Assert.That(questions.Count(), Is.EqualTo(1));
            var question = questions.First();
            var answer = question.Choiches.First();
            Assert.That(answer.Text, Is.EqualTo("answer"));
            Assert.That(answer.Points, Is.EqualTo(1));
            answer = question.Choiches.Skip(1).First();
            Assert.That(answer.Text, Is.EqualTo("wrong"));
            Assert.That(answer.Points, Is.EqualTo(0));
        }
        [Test]
        public void QuestionsWithExtraSpaceBehind_FillSpaceProperty()
        {
            var questions = parse.Parse("question\n\n\n");
            Assert.That(questions.First().Space, Is.EqualTo(3)); 
        }
        [Test]
        public void MultipleQuestions_ReturnsMultiple()
        {
            var questions = parse.Parse("question\n1. answer\n2. secondo\nquestion2\n1. answer2\n2. secondo2\nquestion3\n1. answer3\n2. secondo3");
            Assert.That(questions.Count(), Is.EqualTo(3));
        }
    }
}
