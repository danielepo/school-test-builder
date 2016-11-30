using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseRepository
    {
        private List<Course> Courses = new List<Course>
        {
            new Course("Matematica","Matematica"),
            new Course("Fisica","Fisica"),
            new Course("Italiano","Italiano")
        };
        public Course GetByTitle(string title)
        {
            return Courses.First(x => x.Title == title);
        }
        public IEnumerable<Course> GetAll()
        {
            return Courses;
        }
    }
}
