using System.ComponentModel.DataAnnotations;

namespace QuizH.ViewModels.Exam
{
    public class QuestionImportViewModel
    {
        [Required]
        public string Questions { get; set; }
    }
    
}