using System.Collections.Generic;

namespace QuizH.ViewModels.Exam
{
    public class ExamListViewModel
    {
        public IEnumerable<ExamDetailsViewModel> Exams { get; set; }
    }
}