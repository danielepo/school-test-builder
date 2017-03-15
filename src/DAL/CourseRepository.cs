using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseRepository : ICourseRepository
    {
        private List<Course> Courses = new List<Course>
        {
            new Course(1, "Matematica","Matematica"),
            new Course(2, "Fisica","Fisica"),
            new Course(3, "Italiano","Italiano")
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
