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
            Assert.That(professor.Id.GetType(), Is.EqualTo(typeof(Guid)));
        }
        [Test]
        public void CanGetGuid()
        {
            var guid = new Guid();
            var prof = new Professor()
            {
                Id = guid
            };
            Assert.That(prof.Id, Is.EqualTo(guid));
        }
    }
}

