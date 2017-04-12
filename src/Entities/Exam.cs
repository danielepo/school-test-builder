using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Extensions;
namespace Entities
{
    public class Exam
    {
        public int ExamId { get; set; }

        public string Instructions { get; set; }

        public IList<Question> Questions { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
            Course = new Course();
        }

        public Exam Clone(Random random)
        {
            return new Exam
            {
                Title = Title,
                Instructions = Instructions,
                Questions = Questions.Select(q => q.Clone(random)).Shuffle(random).ToList()
            };
        }

        public void Insert(Question question)
        {
            Questions.Add(question);
        }

        public void Insert(IEnumerable<Question> questions)
        {
            foreach (var question in questions)
            {
                Questions.Add(question);
            }
        }

        public void Remove(Question question)
        {
            Questions.Remove(question);
        }
    }

}
