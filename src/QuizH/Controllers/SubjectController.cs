using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using QuizH.ViewModels.Question;
using System.Linq;
using System.Threading.Tasks;

namespace QuizH.Controllers
{
    public class SubjectController:Controller
    {
        ISubjectRepository subjects;
        public SubjectController(ISubjectRepository subjects)
        {
            this.subjects = subjects;
        }
        public IActionResult Index()
        {
            var vm = subjects.GetAll().Select(x => new SubjectViewModel() { Id = x.SubjectId, Title = x.Title });
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(string title)
        {
            var subject = new Subject(title, 0);
            await subjects.Insert(subject);
            return RedirectToAction("Index");
        }
    }
}
