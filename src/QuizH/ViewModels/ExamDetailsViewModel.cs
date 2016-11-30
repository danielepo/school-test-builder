using System.Collections.Generic;
using System.Linq;
using Entities;

namespace QuizH.ViewModels
{
    public class ExamDetailsViewModel
    {
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string Course { get; set; }
        public List<string> Questions { get; set; }

        public static ExamDetailsViewModel Create(Exam exam)
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