using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizH.Features.Question;
using QuizH.ViewModels.Question;
using System.Threading.Tasks;

namespace QuizH.Controllers
{
    [Authorize(Policy = "Professor")]
    public class QuestionController : Controller
    {
        private readonly IMediator mediator;
        public QuestionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var result = await mediator.SendAsync(new QuestionListQuery());
            return View(result);
        }
        public async Task<IActionResult> Import()
        {
            return View(await mediator.SendAsync(new QuestionImportQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> Import(QuestionImportViewModel vm)
        {
            var result = await mediator.SendAsync(new QuestionImportCommand() { Questions = vm });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Get()
        {
            var result = await mediator.SendAsync(new QuestionListQuery());
            return Json(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await mediator.SendAsync(new QuestionDetailsQuery() { QuestionId = id });
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await mediator.SendAsync(new QuestionUpdateQuery { Id = id });

            return View("Insert", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            var vm = await mediator.SendAsync(new QuestionInsertQuery());

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(QuestionCreationViewModel question)
        {
            var responce =
                await (question.OldId == 0 ?
                mediator.SendAsync(new QuestionInsertCommand { Question = question }) :
                mediator.SendAsync(new QuestionUpdateCommand { Question = question }));

            return RedirectToAction("Index");
        }

    }
}
