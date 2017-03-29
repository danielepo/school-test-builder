using BL;
using DAL;
using Entities;
using Moq;
using NUnit.Framework;
using QuizH.Features.Question;
using QuizH.ViewModels.Question;
using System.Collections.Generic;

namespace App.Test
{
    [TestFixture]
    class QuestionUpdateQueryHandlerTests
    {
        [Test]
        public void QuestionNotFoundThrowsAnException()
        {
            var subjects = new Mock<ISubjectRepository>();
            var questions = new Mock<IQuestionRepository>();
            var courses = new Mock<ICourseRepository>();
            var sut = new QuestionUpdateQueryHandler(subjects.Object, questions.Object, courses.Object);
            var query = new QuestionUpdateQuery()
            {
                Id = 0
            };
            Assert.Throws<QuestionNotFoundException>(() => sut.Handle(query));
        }
        [Test]
        public void ReturnsValidObjectEvenIfLotsOfNulls()
        {
            var subjects = new Mock<ISubjectRepository>();
            var questions = new Mock<IQuestionRepository>();
            questions.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Question("question"));
            var courses = new Mock<ICourseRepository>();
            var sut = new QuestionUpdateQueryHandler(subjects.Object, questions.Object, courses.Object);
            var query = new QuestionUpdateQuery()
            {
                Id = 0
            };
            var result = sut.Handle(query);
            Assert.That(result.Id, Is.EqualTo(0));
            Assert.That(result.SubjectId, Is.EqualTo(0));
            Assert.That(result.OldId, Is.EqualTo(0));
            Assert.That(result.Text, Is.EqualTo("question"));
            Assert.That(result.Answers, Is.EquivalentTo(new List<AnswerViewModel>()));
            Assert.That(result.Courses, Is.EquivalentTo(new List<int>()));
            Assert.That(result.AvailableSubjects, Is.EquivalentTo(new List<SubjectViewModel>()));
            Assert.That(result.AvailableCourses, Is.EquivalentTo(new List<CourseViewModel>() { }));

        }
        [Test]
        public void ReturnsCorrectViewModel()
        {
            var subjects = new Mock<ISubjectRepository>();
            var questions = new Mock<IQuestionRepository>();
            var question = new Question("question")
            {
                Id = 1,
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
                }
            };
            questions.Setup(x => x.GetById(It.IsAny<int>())).Returns(question);
            var courses = new Mock<ICourseRepository>();
            var sut = new QuestionUpdateQueryHandler(subjects.Object, questions.Object, courses.Object);
            var query = new QuestionUpdateQuery()
            {
                Id = 0
            };
            var result = sut.Handle(query);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.SubjectId, Is.EqualTo(2));
            Assert.That(result.OldId, Is.EqualTo(1));
            Assert.That(result.Text, Is.EqualTo("question"));

            Assert.That(result.Answers[0].Text, Is.EqualTo("Vero"));
            Assert.That(result.Answers[0].IsCorrect, Is.EqualTo(false));
            Assert.That(result.Answers[1].Text, Is.EqualTo("Falso"));
            Assert.That(result.Answers[1].IsCorrect, Is.EqualTo(true));

            Assert.That(result.Courses[0], Is.EqualTo(1));
            Assert.That(result.Courses[1], Is.EqualTo(2));

            Assert.That(result.AvailableSubjects, Is.EquivalentTo(new List<SubjectViewModel>()));
            Assert.That(result.AvailableCourses, Is.EquivalentTo(new List<CourseViewModel>() { }));

        }
    }
}
