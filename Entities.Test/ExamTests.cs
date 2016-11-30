using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Entities.Test
{
    [TestFixture]
    public class ExamTests
    {
        [Test]
        public void HasAStringTitle()
        {
            var exam = new Exam();
            Assert.That(exam.Title.GetType(),Is.EqualTo(typeof(string)));
        }
        [Test]
        public void HasAStringInstructions()
        {
            var exam = new Exam();
            Assert.That(exam.Instructions.GetType(), Is.EqualTo(typeof(string)));
        }
        [Test]
        public void HasANumericType()
        {
            var exam = new Exam();
            Assert.That(exam.Type.GetType(), Is.EqualTo(typeof(int)));
        }
        [Test]
        public void HasAMateria()
        {
            var exam = new Exam();
            Assert.That(exam.Course.GetType(), Is.EqualTo(typeof(Course)));
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

