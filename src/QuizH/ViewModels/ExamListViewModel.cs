using System.Collections.Generic;

namespace QuizH.ViewModels
{
    public class ExamListViewModel
    {
        public IEnumerable<ExamDetailsViewModel> Exams { get; set; }
    }
}