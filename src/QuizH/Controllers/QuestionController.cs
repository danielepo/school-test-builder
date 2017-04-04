using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using QuizH.Features.Question;
using QuizH.ViewModels.Question;
using System.Collections.Generic;
using System.IO;

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


        //[HttpPost]
        //public IActionResult UploadFiles(IFormFile file)
        //{
        //    file.SaveAs("<give it a name>");
        //    return Json(new { location = "<url to that file>" });
        //}
        [HttpPost]
        public IActionResult UploadFiles(IList<IFormFile> files)
        {
            long size = 0;
            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                filename = $"Images\\{filename}";

                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            ViewBag.Message = $"{files.Count} file(s) / { size} bytes uploaded successfully!";
            return View();
        }
    }
}
