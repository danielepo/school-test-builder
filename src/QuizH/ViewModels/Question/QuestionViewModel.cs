using System.Collections.Generic;

namespace QuizH.ViewModels.Question
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int SubjectId { get; internal set; }
        public string Text { get; set; }
        public IEnumerable<int> Courses { get; internal set; }
    }
}