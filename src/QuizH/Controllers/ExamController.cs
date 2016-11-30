using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizH.ViewModels;
using Entities;
using DAL;
using MediatR;
using QuizH.Controllers.Commands.Exam;

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
            var vm = _mediator.Send(new QueryExamListViewModel());

            return View(vm);
        }
        [HttpGet]
        public IActionResult Details(string title)
        {
            var vm = _mediator.Send(new QueryExamDetailsViewModel {Title = title});

            return View(vm);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            var vm = _mediator.Send(new QueryInsertExamViewModel());

            return View(vm);
        }
        [HttpPost]
        public IActionResult Insert(ExamCreationViewModel examVM)
        {
            _mediator.Send(new InsertExamCommand {Exam = examVM});

            return RedirectToAction("Index");
        }
    }
}
