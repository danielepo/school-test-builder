using Microsoft.AspNetCore.Mvc;
using MediatR;
using QuizH.Features.Exam;
using QuizH.ViewModels.Exam;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Index()
        {
            var vm = _mediator.Send(new ExamListQuery());

            return View(vm);
        }
        [HttpGet]
        public IActionResult Details(string title)
        {
            var vm = _mediator.Send(new ExamDetailsQuery { Title = title });

            return View(vm);
        }
        [HttpGet]
        public IActionResult Edit(string title)
        {
            var vm = _mediator.Send(new ExamUpdateQuery { Title = title });

            return View("Insert",vm);
        }
        
        [HttpGet]
        public IActionResult Insert()
        {
            var vm = _mediator.Send(new ExamInsertQuery());

            return View(vm);
        }
        [HttpPost]
        public IActionResult Insert(ExamCreationViewModel exam)
        {
            if(exam.Id == 0)
                _mediator.Send(new ExamInsertCommand { Exam = exam });
            else
                _mediator.Send(new ExamUpdateCommand { Exam = exam });

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Download(int id)
        {
            var vm = _mediator.Send(new ExamDownloadQuery { Id = id });
            return File(vm.Stream, "application/zip", vm.FileName);
        }
    }
}
