using System.Collections.Generic;
using Entities;

namespace DAL
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetByTitle(string title);
    }
}