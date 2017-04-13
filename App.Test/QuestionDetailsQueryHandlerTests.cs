using BL;
using DAL;
using Entities;
using Moq;
using NUnit.Framework;
using QuizH.Features.Question;
using QuizH.ViewModels.Question;
using System.Collections.Generic;
using System.Linq;
namespace App.Test
{
    [TestFixture]
    class QuestionDetailsQueryHandlerTests
    {
        [Test]
        public void QuestionNotFoundThrowsAnException()
        {
            var questions = new Mock<IQuestionRepository>();
            var question = new Question("irrelevant")
            {
                QuestionId = 1,
                Subject = new Subject("subject", 2),
                Courses = new List<Course>
                {
                    new Course(1,"course1","first"),
                    new Course(2,"course2","second"),
                },
                Choiches = new List<Answer>()
                {
                    new Answer("Vero"),
                    new Answer("Falso",1)
                },
                Space = 5
            };
            questions.Setup(x => x.GetById(It.IsAny<int>())).Returns(question);
            var sut = new QuestionDetailsQueryHandler(questions.Object);
            var query = new QuestionDetailsQuery()
            {
                QuestionId = 1
            };
            var result = sut.Handle(query);

            Assert.That(result.Text, Is.EqualTo("irrelevant"));
            Assert.That(result.Courses.Count, Is.EqualTo(2));
            Assert.That(result.Courses.ToList()[0], Is.EqualTo("course1"));
            Assert.That(result.Courses.ToList()[1], Is.EqualTo("course2"));
            Assert.That(result.Options.Count, Is.EqualTo(2));
            Assert.That(result.Options.ToList()[0].Text, Is.EqualTo("Vero"));
            Assert.That(result.Options.ToList()[0].IsCorrect, Is.EqualTo(false));
            Assert.That(result.Options.ToList()[1].Text, Is.EqualTo("Falso"));
            Assert.That(result.Options.ToList()[1].IsCorrect, Is.EqualTo(true));
            Assert.That(result.FreeTextLines, Is.EqualTo(5));
            Assert.That(result.Subject, Is.EqualTo("subject"));
        }
        
    }
}
