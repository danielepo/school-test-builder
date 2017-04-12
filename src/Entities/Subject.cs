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

        public Subject()
        {
            SubjectId = 0;
            Title = "";
        }
        public Subject(string subject, int id)
        {
            Title = subject;
            SubjectId = id;
        }
    }
}