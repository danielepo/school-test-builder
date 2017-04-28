using Microsoft.AspNetCore.Mvc;
using MediatR;
using QuizH.Features.Exam;
using QuizH.ViewModels.Exam;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizH.Controllers
{
    [Authorize(Policy = "Professor")]
    public class ExamController : Controller
    {
        private readonly IMediator _mediator;

        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var vm = await _mediator.SendAsync(new ExamListQuery());
            
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string title)
        {
            var vm = await _mediator.SendAsync(new ExamDetailsQuery { Title = title });

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string title)
        {
            var vm = await _mediator.SendAsync(new ExamUpdateQuery { Title = title });

            return View("Insert",vm);
        }
        
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            var vm = await _mediator.SendAsync(new ExamInsertQuery());

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ExamCreationViewModel exam)
        {
            if(exam.Id == 0)
                await _mediator.SendAsync(new ExamInsertCommand { Exam = exam });
            else
                await _mediator.SendAsync(new ExamUpdateCommand { Exam = exam });

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Download(int id)
        {
            var vm = await _mediator.SendAsync(new ExamDownloadQuery { Id = id });
            return File(vm.Stream, "application/zip", vm.FileName);
        }
    }
}
