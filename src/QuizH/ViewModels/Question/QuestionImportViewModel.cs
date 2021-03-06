using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizH.ViewModels.Question
{
    public class QuestionImportViewModel
    {
        [Required]
        public string Questions { get; set; }

        public string Subject { get; set; }
        public List<string> AvailableSubjects { get; set; }
    }
}