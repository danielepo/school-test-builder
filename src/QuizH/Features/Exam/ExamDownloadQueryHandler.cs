using System;
using DAL;
using MediatR;
using QuizH.ViewModels.Exam;
using BL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public ExamDownloadQueryHandler(IExamRepository repository)
        {
            this.repository = repository;
        }

        public Task<ExamDownloadViewModel> Handle(ExamDownloadQuery message)
        {
            return Task.Run(() =>
            {
                var exam = repository.GetById(message.Id);
                var exams = generator.Create(exam, 4);

                var files = new List<FileData>();
                foreach (var e in exams)
                {
                    files.Add(CreateExamFile(e.Key, e.Value));
                }
                files.Add(CreateAnswersFile(exams));
                return new ExamDownloadViewModel
                {
                    Stream = zipper.Zip(files),
                    FileName = parser.Parse(exam.Title) + ".zip"
                };
            });
        }

        private FileData CreateAnswersFile(IDictionary<int, Entities.Exam> exams)
        {
            var answers = extractor.Extract(exams.Select(x => x.Value));
            var stream = writer.GetStream(answers);
            return new FileData("risposte.xlsx", stream);
        }

        private FileData CreateExamFile(int type, Entities.Exam e)
        {
            var stream = documenter.GetStream(type, e);
            var file = new FileData($"{parser.Parse(e.Title)} - {type}.docx", stream);
            return file;
        }
    }
}