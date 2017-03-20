using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizH.ViewModels.Question
{
    public class QuestionCreationViewModel
    {
        public int Id { get;  set; }
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public List<int> Courses { get; set; }
        public List<SubjectViewModel> AvailableSubjects { get; set; }
        public List<CourseViewModel> AvailableCourses { get; set; }
        public int SubjectId { get; set; }
        public int OldId { get; set; }
    }
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}