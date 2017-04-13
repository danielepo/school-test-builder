using QuizH.ViewModels.Question;
using System.Collections.Generic;
using System.Linq;

namespace QuizH.ViewModels.Exam
{
    public class ExamDetailsViewModel
    {
        public string Title { get; set; }
        public int Id{ get; set; }
        public string Instructions { get; set; }
        public string Course { get; set; }
        public List<QuestionViewModel> Questions { get; set; }

        public static ExamDetailsViewModel Create(Entities.Exam exam)
        {
            return new ExamDetailsViewModel
            {
                Id = exam.ExamId,
                Title = exam.Title,
                Course = exam.Course.Title,
                Instructions = exam.Instructions,
                Questions = exam.Questions.Select(x => new QuestionViewModel
                {
                    Id = x.QuestionId,
                    Text = x.Text
                }).ToList(),
            };
        }

    }
}