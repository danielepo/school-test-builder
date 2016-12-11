using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuizH.ViewModels;
using Entities;
using MediatR;
using QuizH.Features.Exam;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizH.Controllers
{
    public class InMemoryExams
    {
        public static List<Exam> Exams = new List<Exam>();
    }
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

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(EditExamViewModel exam)
        {
            _mediator.Send(new ExamUpdateCommand { Exam = exam });

            return RedirectToAction("Details", new { exam.Title });
        }
        [HttpGet]
        public IActionResult Insert()
        {
            var vm = _mediator.Send(new ExamInsertQuery());

            return View(vm);
        }
        [HttpPost]
        public IActionResult Insert(ExamCreationViewModel examVM)
        {
            _mediator.Send(new ExamInsertCommand { Exam = examVM });

            return RedirectToAction("Index");
        }
    }
}
