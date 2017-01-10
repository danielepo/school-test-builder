using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;
using System.Collections.Generic;
using QuizH.ViewModels.Question;

namespace QuizH.Features.Exam
{
    public class ExamInsertQueryHandler : IRequestHandler<ExamInsertQuery, ExamCreationViewModel>
    {
        readonly ICourseRepository courses;
        readonly IQuestionRepository questions;
        //private readonly ExamRepository _context;
        public ExamInsertQueryHandler(IQuestionRepository questions, ICourseRepository courses)
        {
            this.questions = questions;
            this.courses = courses;
        }


        public ExamCreationViewModel Handle(ExamInsertQuery message)
        {
            return new ExamCreationViewModel
            {
                AvailableCourses = courses.GetAll().Select(x => x.Title).ToList(),
                //AvailableQuestions = questions.GetAll()
                //    .Select(x =>
                //        new QuestionViewModel {
                //            Id = x.Id,
                //            Text = x.Text
                //        })

            };
        }
    }
}