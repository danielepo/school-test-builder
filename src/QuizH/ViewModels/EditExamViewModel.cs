using Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QuizH.ViewModels
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
        public List<string> AvailableQuestions { get; set; }

        public static EditExamViewModel Create(Exam exam)
        {
            return 
        }
    }
    
}