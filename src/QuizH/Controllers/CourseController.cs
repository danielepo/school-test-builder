using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using QuizH.ViewModels.Question;
using System.Linq;
using System.Threading.Tasks;

namespace QuizH.Controllers
{
    public class CourseController:Controller
    {
        ICourseRepository courses;
        public CourseController(ICourseRepository courses)
        {
            this.courses = courses;
        }
        public IActionResult Index()
        {
            var vm = courses.GetAll().Select(x => new CourseViewModel() { Id = x.CourseId, Title = x.Title });
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(string title, string description)
        {
            var course = new Course(0, title, description);
            await courses.Insert(course);
            return RedirectToAction("Index");
        }
    }
}
