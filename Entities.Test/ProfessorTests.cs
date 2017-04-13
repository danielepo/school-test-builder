using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;

namespace Entities.Test
{
    [TestFixture]
    public class ProfessorTests
    {

        [Test]
        public void HasAGuidId()
        {
            var professor = new Professor();
            Assert.That(professor.ProfessorId.GetType(), Is.EqualTo(typeof(Guid)));
        }
        [Test]
        public void CanGetGuid()
        {
            var guid = new Guid();
            var prof = new Professor()
            {
                ProfessorId = guid
            };
            Assert.That(prof.ProfessorId, Is.EqualTo(guid));
        }
    }
}

