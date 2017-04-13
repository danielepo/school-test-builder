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
    class QuestionInsertCommandHandlerForTest : QuestionInsertCommandHandler
    {
        public QuestionInsertCommandHandlerForTest(IQuestionRepository questions, ICourseRepository courses, ISubjectRepository subjects) : base(questions, courses, subjects)
        {
        }

        public void Handle(QuestionInsertCommand command)
        {
            HandleCore(command);
        }
    }
    [TestFixture]
    class QuestionInsertCommandHandlerTests
    {
        [Test]
        public void DontThrowsEvenWithInvalidInput()
        {
            var subjects = new Mock<ISubjectRepository>();
            var questions = new Mock<IQuestionRepository>();
            var courses = new Mock<ICourseRepository>();
            var sut = new QuestionInsertCommandHandlerForTest(questions.Object, courses.Object, subjects.Object);
            var query = new QuestionInsertCommand()
            {
                Question = new QuestionCreationViewModel()
            };
            sut.Handle(query);

            questions.Verify(x => x.Add(It.IsAny<Question>()), Times.Once);
        }
        [Test]
        public void AddsEntityCorrectly()
        {
            var subjects = new Mock<ISubjectRepository>();
            subjects.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Subject("subject", 2));

            var vm = new QuestionCreationViewModel
            {
                Answers = new List<AnswerViewModel>
                {
                    new AnswerViewModel
                    {
                        IsCorrect = true,
                        Text = "Falso"
                    },
                    new AnswerViewModel
                    {
                        Text = "True"
                    }
                },
                Courses = new List<int> { 1 },
                Text = "question",
                SubjectId = 2,
                FreeTextLines = 5
            };
            var questions = new Mock<IQuestionRepository>();
            Question saveObj = null;
            questions.Setup(x => x.Add(It.IsAny<Question>())).Callback<Question>(x => saveObj = x);
            var courses = new Mock<ICourseRepository>();
            courses.Setup(x => x.GetAll()).Returns(new List<Course>
                {
                    new Course(1,"course1","first"),
                });


            var sut = new QuestionInsertCommandHandlerForTest(questions.Object, courses.Object, subjects.Object);
            var query = new QuestionInsertCommand()
            {
                Question = vm
            };
            sut.Handle(query);

            questions.Verify(x => x.Add(It.IsAny<Question>()), Times.Once);
            Assert.That(saveObj.Space, Is.EqualTo(5));
            Assert.That(saveObj.Subject.SubjectId, Is.EqualTo(2));
            Assert.That(saveObj.Courses.Count, Is.EqualTo(1));
            Assert.That(saveObj.Courses.First().CourseId, Is.EqualTo(1));
            Assert.That(saveObj.Text, Is.EqualTo("question"));
            Assert.That(saveObj.Choiches.Count, Is.EqualTo(2));
            Assert.That(saveObj.Choiches.First().Text, Is.EqualTo("Falso"));
            Assert.That(saveObj.Choiches.First().Points, Is.EqualTo(1));
        }


    }
}
