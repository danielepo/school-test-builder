using System;

namespace Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Course(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("title");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("description");

            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Title} - {Description}";
        }
    }
}