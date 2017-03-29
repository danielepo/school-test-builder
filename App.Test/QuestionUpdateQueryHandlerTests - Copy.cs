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
    class QuestionUpdateCommandHandlerTests
    {
        class QuestionUpdateCommandHandlerForTest: QuestionUpdateCommandHandler
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
            var sut = new QuestionUpdateCommandHandlerForTest( questions.Object, courses.Object, subjects.Object);
            var query = new QuestionUpdateCommand()
            {
                Question = new QuestionCreationViewModel()
            };
            sut.Handle(query);

            questions.Verify(x => x.Update(It.IsAny<Question>(), It.IsAny<Question>()), Times.Once);
        }
     
    }
}
