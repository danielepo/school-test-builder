using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;

namespace Entities.Test
{
    [TestFixture]
    public class SubjectTests
    {

        [Test]
        public void HasAIntId()
        {
            var sut = new Subject("",1);
            Assert.That(sut.SubjectId.GetType(), Is.EqualTo(typeof(int)));
        }
        [Test]
        public void HasAIntTitle()
        {
            var sut = new Subject("", 1);
            Assert.That(sut.Title.GetType(), Is.EqualTo(typeof(string)));
        }
        [Test]
        public void CanReadTitleAndId()
        {
            var sut = new Subject("title", 1);
            Assert.That(sut.SubjectId, Is.EqualTo(1));
            Assert.That(sut.Title, Is.EqualTo("title"));
        }
    }
}

