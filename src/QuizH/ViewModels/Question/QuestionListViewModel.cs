using System.Collections.Generic;
using Entities;
using QuizH.ViewModels.Exam;

namespace QuizH.ViewModels.Question
{
    public class QuestionListViewModel
    {
        public List<QuestionViewModel> Questions { get; set; }
        public IEnumerable<Subject> Subjects { get; internal set; }
        public IEnumerable<Course> Courses { get; internal set; }
    }
}