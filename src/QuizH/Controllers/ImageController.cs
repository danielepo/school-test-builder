using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;

namespace QuizH.Controllers
{

    [Authorize(Policy = "Professor")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public ImageController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public IActionResult UploadFiles(IFormFile file)
        {
            long size = 0;
            var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
            var guid = Guid.NewGuid().ToString();
            filename = $@"{guid}-{filename}";
            var folder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
            
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            size += file.Length;
            using (FileStream fs = System.IO.File.Create(Path.Combine(folder,filename)))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return Json(new { location = $@"\images\{filename}"});
        }
        
    }
}
