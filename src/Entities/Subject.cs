using Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Subject
    {
        public string Title { get; set; }
        public int Id { get; set; }

        public Subject(string subject, int id)
        {
            Title = subject;
            Id = id;
        }
    }
}