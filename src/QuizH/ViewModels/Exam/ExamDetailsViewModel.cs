using System.Collections.Generic;
using System.Linq;

namespace QuizH.ViewModels.Exam
{
    public class ExamDetailsViewModel
    {
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string Course { get; set; }
        public List<string> Questions { get; set; }

        public static ExamDetailsViewModel Create(Entities.Exam exam)
        {
            return new ExamDetailsViewModel
            {
                Title = exam.Title,
                Course = exam.Course.Title,
                Instructions = exam.Instructions,
                Questions = exam.Questions.Select(x => x.Text).ToList(),
            };
        }

    }
}