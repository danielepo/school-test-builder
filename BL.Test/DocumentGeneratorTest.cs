using DocumentFormat.OpenXml.Packaging;
using Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace BL.Test
{
    [TestFixture]
    public class DocumentGeneratorTest
    {
        DocumentGenerator generator = new DocumentGenerator();

        IEnumerable<Question> questions = new List<Question>
        {
            new Question("Domanda 1")
            {
                Choices = new List<Answer>
                {
                    new Answer("risposta 1"),
                    new Answer("risposta 2"),
                    new Answer("risposta 3"),
                }
            },
            new Question("Domanda 2")
            {
                Choices = new List<Answer>
                {
                    new Answer("risposta 4"),
                    new Answer("risposta 5"),
                    new Answer("risposta 6"),
                }
            },
            new Question("Domanda 3")
            {
                Choices = new List<Answer>
                {
                    new Answer("risposta 7"),
                    new Answer("risposta 8"),
                    new Answer("risposta 9"),
                }
            },
            new Question("Domanda 4")
            {
                Choices = new List<Answer>
                {
                    new Answer("risposta 10"),
                    new Answer("risposta 11"),
                    new Answer("risposta 12"),
                }
            },
            new Question("Domanda 5")
            {
                Choices = new List<Answer>
                {
                    new Answer("risposta 13"),
                    new Answer("risposta 14"),
                    new Answer("risposta 15"),
                }
            },
        };

        [Test]
        public void BasicExamGeneration()
        {
            var exam = new Exam
            {
                Title = "Titolo",
                Instructions =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
            };
            exam.Insert(questions);
            generator.Create(exam);
        }
        [Test]
        public void GetStream_GivenExam_RetursNotNull()
        {
            var exam = new Exam();
            var stream = generator.GetStream(exam);
            Assert.That(stream, Is.Not.Null);
        }
        [Test]
        public void GetStream_GivenExam_RetursDocument()
        {
            var exam = new Exam
            {
                Title = "Titolo",
                Instructions =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"
            };
            exam.Insert(questions);
            var stream = generator.GetStream(exam);
            var package = WordprocessingDocument.Open(stream, false);
            Assert.That(package, Is.Not.Null);
            var xml = package.MainDocumentPart.Document.OuterXml;
            Assert.That(xml, Contains.Substring(exam.Title));
            Assert.That(xml, Contains.Substring(exam.Instructions));
        }
    }
}