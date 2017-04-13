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
    class QuestionUpdateCommandHandlerTests
    {
        class QuestionUpdateCommandHandlerForTest : QuestionUpdateCommandHandler
        {
            public QuestionUpdateCommandHandlerForTest(IQuestionRepository questions, ICourseRepository courses, ISubjectRepository subjects) : base(questions, courses, subjects)
            {
            }

            public void Handle(QuestionUpdateCommand command)
            {
                HandleCore(command);
            }
        }
        [Test]
        public void DontThrowsEvenWithInvalidInput()
        {
            var subjects = new Mock<ISubjectRepository>();
            var questions = new Mock<IQuestionRepository>();
            var courses = new Mock<ICourseRepository>();
            var sut = new QuestionUpdateCommandHandlerForTest(questions.Object, courses.Object, subjects.Object);
            var query = new QuestionUpdateCommand()
            {
                Question = new QuestionCreationViewModel()
            };
            sut.Handle(query);

            questions.Verify(x => x.Update(It.IsAny<Question>(), It.IsAny<Question>()), Times.Once);
        }
        [Test]
        public void UpdatesEntityCorrectly()
        {
            var subjects = new Mock<ISubjectRepository>();
            subjects.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Subject("subject", 2));

            var vm = new QuestionCreationViewModel
            {
                OldId = 2,
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
            var course = new Course(1, "course1", "first");
            var questions = new Mock<IQuestionRepository>();
            var oldQuestion = new Question("oldQuestion")
            {
                QuestionId = 2,
                Space = 3
            };
            questions.Setup(x => x.GetById(It.IsAny<int>())).Returns(oldQuestion);
            Question newObj = null;
            Question oldObj = null;
            questions
                .Setup(x => x.Update(It.IsAny<Question>(), It.IsAny<Question>()))
                .Callback<Question, Question>((x, y) => { newObj = y; oldObj = x; });
            var courses = new Mock<ICourseRepository>();
            courses.Setup(x => x.GetAll()).Returns(new List<Course>
                {
                    course,
                });


            var sut = new QuestionUpdateCommandHandlerForTest(questions.Object, courses.Object, subjects.Object);
            var query = new QuestionUpdateCommand()
            {
                Question = vm
            };
            sut.Handle(query);

            questions.Verify(x => x.Update(It.IsAny<Question>(), It.IsAny<Question>()), Times.Once);

            Assert.That(oldObj.QuestionId, Is.EqualTo(2));
            Assert.That(oldObj.Space, Is.EqualTo(3));

            Assert.That(newObj.Space, Is.EqualTo(5));
            Assert.That(newObj.Subject.SubjectId, Is.EqualTo(2));
            Assert.That(newObj.Courses.Count, Is.EqualTo(1));
            Assert.That(newObj.Courses.First().CourseId, Is.EqualTo(1));
            Assert.That(newObj.Text, Is.EqualTo("question"));
            Assert.That(newObj.Choiches.Count, Is.EqualTo(2));
            Assert.That(newObj.Choiches.First().Text, Is.EqualTo("Falso"));
            Assert.That(newObj.Choiches.First().Points, Is.EqualTo(1));
        }

    }
}
