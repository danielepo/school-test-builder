using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizH.Features.Question;
using QuizH.ViewModels.Question;

namespace QuizH.Controllers
{
    public class QuestionController:Controller
    {
        private readonly IMediator mediator;

        public QuestionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
