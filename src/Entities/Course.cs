using System;

namespace Entities
{
    public class Course
    {
        public int CourseId {get; private set;}
        public string Title { get; private set; }
        public string Description { get; private set; }

        public Course()
        {
            Title = "";
            Description = "";
        }
        public Course(int id, string title, string description)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("title");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("description");

            CourseId = id;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Title} - {Description}";
        }
    }
}