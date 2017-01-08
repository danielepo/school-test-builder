using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizH.ViewModels.Exam
{
    public class EditExamViewModel
    {
        public string OldTitle { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Instructions { get; set; }
        public string Course { get; set; }
        public List<string> AvailableCourses { get; set; }
        public List<string> Questions { get; set; }
        public List<QuestionViewModel> AvailableQuestions { get; set; }

    }
    
}