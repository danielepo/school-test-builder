﻿using BL;
using BL.Interfaces;
using DAL;
using MediatR;
using System.Linq;

namespace QuizH.Features.Question
{
    public class QuestionImportCommandHandler : RequestHandler<QuestionImportCommand>
    {
        private IQuestionParser parser;
        private IQuestionRepository repository;
        private ISubjectRepository subjectRepo;

        public QuestionImportCommandHandler(IQuestionParser parser, IQuestionRepository repository, ISubjectRepository subjectRepo)
        {
            this.parser = parser;
            this.repository = repository;
            this.subjectRepo = subjectRepo;
        }

        protected override void HandleCore(QuestionImportCommand message)
        {
            var vm = message.Questions;
            var questions = parser.Parse(vm.Questions);
            var subject = subjectRepo.GetByTitle(vm.Subject);
            foreach (var q in questions)
            {
                q.Subject = subject;
                repository.Add(q);
            }
        }
    }
}