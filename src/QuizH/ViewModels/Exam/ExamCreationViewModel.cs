using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QuizH.ViewModels.Question;

namespace QuizH.ViewModels.Exam
{
    public class ExamCreationViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Instructions { get; set; }
        public string Course { get; set; }
        public List<string> AvailableCourses { get; set; }
        public List<int> Questions { get; set; }
        public int Id { get;  set; }
    }
    
}