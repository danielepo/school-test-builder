using System.Linq;
using DAL;
using MediatR;
using QuizH.ViewModels;
using QuizH.ViewModels.Question;
using System.Collections.Generic;
using QuizH.ViewModels.Question;
using System.Threading.Tasks;

namespace QuizH.Features.Question
{
    public class QuestionInsertQueryHandler : IAsyncRequestHandler<QuestionInsertQuery, QuestionCreationViewModel>
    {
        readonly ICourseRepository courses;
        readonly ISubjectRepository subjects;
        //private readonly QuestionRepository _context;
        public QuestionInsertQueryHandler(ISubjectRepository subjects, ICourseRepository courses)
        {
            this.subjects = subjects;
            this.courses = courses;
        }


        public Task<QuestionCreationViewModel> Handle(QuestionInsertQuery message)
        {
            return Task.Run(() => new QuestionCreationViewModel
            {
                AvailableCourses = courses.GetAll().Select(x => new CourseViewModel { Id = x.CourseId, Title = x.Title }).ToList(),
                AvailableSubjects = subjects.GetAll().Select(x => new SubjectViewModel { Id = x.SubjectId, Title = x.Title }).ToList(),
            });
        }
    }
}