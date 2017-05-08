using System.Collections.Generic;
using Entities;
using System.Threading.Tasks;
using System.Linq;

namespace DAL
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetByTitle(string title);
        Course GetById(int id);
        Task Insert(Course course);
    }
}