using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }

        public Subject(string subject)
        {
            Title = subject;
        }
    }
}