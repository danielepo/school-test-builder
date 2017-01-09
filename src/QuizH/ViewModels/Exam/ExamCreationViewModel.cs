using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<string> Questions { get; set; }
        public IEnumerable<QuestionViewModel> AvailableQuestions { get; set; }
    }
    
}