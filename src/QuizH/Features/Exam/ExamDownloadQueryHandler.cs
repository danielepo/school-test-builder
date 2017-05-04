using System;
using DAL;
using MediatR;
using QuizH.ViewModels.Exam;
using BL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuizH.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Entities;
//using Microsoft.AspNetCore.Http;

namespace QuizH.Features.Exam
{
    public class ExamDownloadQueryHandler : IAsyncRequestHandler<ExamDownloadQuery, ExamDownloadViewModel>
    {
        private readonly IExamRepository repository;
        private readonly ExamGenerator generator = new ExamGenerator();
        private readonly DocumentGenerator documenter = new DocumentGenerator();
        private readonly AnswerExtractor extractor = new AnswerExtractor();
        private readonly AnswerSheetWriter writer = new AnswerSheetWriter();
        private readonly Zipper zipper = new Zipper();
        private readonly HtmlStringParser parser = new HtmlStringParser();
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfessorRepository professors;
        private readonly ClaimsPrincipal user;

        private Task<ApplicationUser> CurrentUserAsync => userManager.GetUserAsync(user);

        public ExamDownloadQueryHandler(IExamRepository repository, UserManager<ApplicationUser> userManager, IProfessorRepository professors)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.professors = professors;
        }

        public async Task<ExamDownloadViewModel> Handle(ExamDownloadQuery message)
        {
            var exam = repository.GetById(message.Id);
            var exams = generator.Create(exam, 4);
            var appUser = await userManager.GetUserAsync(message.User);
            var professor = professors.GetById(appUser.Id);
            documenter.professor = professor;
             
            var files = new List<FileData>();
            foreach (var e in exams)
            {
                files.Add(await CreateExamFile(e.Key, e.Value));
            }
            files.Add(CreateAnswersFile(exams));
            return new ExamDownloadViewModel
            {
                Stream = zipper.Zip(files),
                FileName = parser.Parse(exam.Title) + ".zip"
            };
        }

        private FileData CreateAnswersFile(IDictionary<int, Entities.Exam> exams)
        {
            var answers = extractor.Extract(exams.Select(x => x.Value));
            var stream = writer.GetStream(answers);
            return new FileData("risposte.xlsx", stream);
        }

        private async Task<FileData> CreateExamFile(int type, Entities.Exam e)
        {
            var stream = documenter.GetStream(type, e);
            var file = new FileData($"{parser.Parse(e.Title)} - {type}.docx", stream);
            return file;
        }
    }
}