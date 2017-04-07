using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizH.Features.Question;
using QuizH.ViewModels.Question;

namespace QuizH.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IMediator mediator;
        public QuestionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            var result = mediator.Send(new QuestionListQuery());
            return View(result);
        }
        public IActionResult Import()
        {
            return View(mediator.Send(new QuestionImportQuery()));
        }
        [HttpPost]
        public IActionResult Import(QuestionImportViewModel vm)
        {
            var result = mediator.Send(new QuestionImportCommand() { Questions = vm });
            return RedirectToAction("Index");
        }
        public IActionResult Get()
        {
            var result = mediator.Send(new QuestionListQuery());
            return Json(result);
        }

        public IActionResult Details(int id)
        {
            var result = mediator.Send(new QuestionDetailsQuery() { QuestionId = id });
            return View(result);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vm = mediator.Send(new QuestionUpdateQuery { Id = id });

            return View("Insert", vm);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            var vm = mediator.Send(new QuestionInsertQuery());

            return View(vm);
        }
        [HttpPost]
        public IActionResult Insert(QuestionCreationViewModel question)
        {
            var responce =
                question.OldId == 0 ?
                mediator.Send(new QuestionInsertCommand { Question = question }) :
                mediator.Send(new QuestionUpdateCommand { Question = question });

            return RedirectToAction("Index");
        }
        
    }
}
