using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizH.ViewModels.Question
{
    public class AnswerViewModel
    {
        public AnswerViewModel() { }
        public AnswerViewModel(Entities.Answer answer)
        {
            Text = answer.Text;
            IsCorrect = answer.Points >= 1;
        }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
    public class QuestionCreationViewModel
    {
        public int Id { get;  set; }
        public string Text { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
        public List<int> Courses { get; set; }
        public List<SubjectViewModel> AvailableSubjects { get; set; }
        public List<CourseViewModel> AvailableCourses { get; set; }
        public int SubjectId { get; set; }
        public int OldId { get; set; }
        public int FreeTextLines { get; set; }
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
        public string Description { get; set; }
    }
}