using System;
using DAL;
using MediatR;
using QuizH.ViewModels.Exam;
using BL;
using System.Collections.Generic;
using System.Linq;
namespace QuizH.Features.Exam
{
    public class ExamDownloadQueryHandler : IRequestHandler<ExamDownloadQuery, ExamDownloadViewModel>
    {
        private readonly IExamRepository repository;
        readonly ExamGenerator generator = new ExamGenerator();
        readonly DocumentGenerator documenter = new DocumentGenerator();
        readonly AnswerExtractor extractor = new AnswerExtractor();
        readonly AnswerSheetWriter writer = new AnswerSheetWriter();
        readonly Zipper zipper = new Zipper();
        public ExamDownloadQueryHandler(IExamRepository exams)
        {
            this.repository = exams;
        }

        public ExamDownloadViewModel Handle(ExamDownloadQuery message)
        {
            var exam = repository.GetById(message.Id);
            var exams = generator.Create(exam, 4);
            var files = new List<FileData>();
            foreach (var e in exams)
                files.Add(CreateExamFile(e.Key,e.Value));
            files.Add(CreateAnswersFile(exams));
            return new ExamDownloadViewModel()
            {
                Stream = zipper.Zip(files),
                FileName = exam.Title + ".zip"
            };
        }

        private FileData CreateAnswersFile(IDictionary<int,Entities.Exam> exams)
        {
            var answers = extractor.Extract(exams.Select(x => x.Value));
            var stream = writer.GetStream(answers);
            return new FileData("risposte.xlsx", stream);
        }

        private FileData CreateExamFile(int type, Entities.Exam e)
        {
            var stream = documenter.GetStream(type, e);
            var file = new FileData($"{e.Title} - {type}.docx", stream);
            return file;
        }
    }
}