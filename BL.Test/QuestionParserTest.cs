using Entities;
using NUnit.Framework;
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
        [Test]
        public void EmptyStringReturnsNotNull()
        {
            var parse = new QuestionParser();
            IEnumerable<Question> questions = parse.Parse("");
            Assert.That(questions, Is.Not.Null);
        }
    }
}
