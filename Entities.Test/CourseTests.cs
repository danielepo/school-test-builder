﻿using System;
using NUnit.Framework;

namespace Entities.Test
{
    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void CourseGetsCreatedWithTitleAndDescription()
        {
            var course = new Course("title", "description");
            Assert.That(course.Title, Is.EqualTo("title"));
            Assert.That(course.Description, Is.EqualTo("description"));
        }

        [Test]
        public void CourseCannotHaveNullTitle()
        {
            Assert.Throws<ArgumentException>(() => new Course(null, null));
        }
        [Test]
        public void CourseCannotHaveEmptyTitle()
        {
            Assert.Throws<ArgumentException>(() => new Course("", null));
        }

        [Test]
        public void CourseCannotHaveNullDescription()
        {
            Assert.Throws<ArgumentException>(() => new Course("title", null));
        }
        [Test]
        public void CourseCannotHaveEmptyDescription()
        {
            Assert.Throws<ArgumentException>(() => new Course("title", ""));
        }
    }
}