using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Exam;
using System.Collections.Generic;
using QuizH.ViewModels.Question;
using System.Threading.Tasks;

namespace QuizH.Features.Exam
{
    public class ExamInsertQueryHandler : IAsyncRequestHandler<ExamInsertQuery, ExamCreationViewModel>
    {
        readonly ICourseRepository courses;
        readonly IQuestionRepository questions;
        //private readonly ExamRepository _context;
        public ExamInsertQueryHandler(IQuestionRepository questions, ICourseRepository courses)
        {
            this.questions = questions;
            this.courses = courses;
        }


        public Task<ExamCreationViewModel> Handle(ExamInsertQuery message)
        {
            return Task.Run(() =>
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
            });
        }
    }
}