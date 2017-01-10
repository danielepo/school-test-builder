using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;
using System.Collections.Generic;
using System;
using QuizH.Features.Exam;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Question
{
    public class QuestionListQueryHandler : IRequestHandler<QuestionListQuery, QuestionListViewModel>
    {
        readonly IQuestionRepository questions;
        //private readonly ExamRepository _context;
        public QuestionListQueryHandler(IQuestionRepository questions)
        {
            this.questions = questions;
        }

        public QuestionListViewModel Handle(QuestionListQuery message)
        {
            return new QuestionListViewModel()
            {
                Questions = questions.GetAll().Select(x => new QuestionViewModel
                {
                    Text = x.Text,
                    Id = x.Id
                }).ToList()
            };
        }
        
    }
}