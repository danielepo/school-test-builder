using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Entities.Extensions;

namespace Entities.Test
{
    [TestFixture]
    public class ExamTests
    {
        [Test]
        public void HasACourse()
        {
            var exam = new Exam();
            Assert.That(exam.Course.GetType(), Is.EqualTo(typeof(Course)));
        }

        [Test]
        public void HasAnId()
        {
            var exam = new Exam();
            Assert.That(exam.ExamId.GetType(), Is.EqualTo(typeof(int)));
        }


        [Test]
        public void CanGetBasicProperties()
        {
            var exam = new Exam()
            {
                ExamId = 2,
                Title = "irrelevant"
            };
            Assert.That(exam.ExamId, Is.EqualTo(2));
            Assert.That(exam.Title, Is.EqualTo("irrelevant"));
        }
        [Test]
        public void AnNewExamHasNoQuestions()
        {
            var exam = new Exam();
            Assert.That(exam.Questions.Count(), Is.EqualTo(0));
        }
        [Test]
        public void CanInsertQuestion()
        {
            var exam = new Exam();
            exam.Insert(new Question("irrilevant"));
            Assert.That(exam.Questions.Count(),Is.EqualTo(1));
        }
        [Test]
        public void CanRemoveQuestion()
        {
            var exam = new Exam();
            var question = new Question("irrilevant");
            exam.Insert(question);
            Assert.That(exam.Questions.Count(), Is.EqualTo(1));
            exam.Remove(question);
            Assert.That(exam.Questions.Count(), Is.EqualTo(0));

        }
    }
}

