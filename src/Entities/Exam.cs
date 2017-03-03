using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Extensions;
namespace Entities
{   public static class ExamExtension
    {
        public static Exam Clone(this Exam exam, Random random)
        {
            return new Exam
            {
                Title = exam.Title,
                Instructions = exam.Instructions,
                Questions = exam.Questions.Select(q => q.Clone(random)).Shuffle(random).ToList()
            };
        }
        public static void Insert(this Exam exam, Question question)
        {
            exam.Questions.Add(question);
        }

        public static void Insert(this Exam exam, IEnumerable<Question> questions)
        {
            foreach (var question in questions)
            {
                exam.Questions.Add(question);
            }
        }
        public static void Remove(this Exam exam, Question question)
        {
            exam.Questions.Remove(question);
        }

    }
    public class Exam
    {
        public string Instructions { get; set; }

        public IList<Question> Questions { get; set; }

        public string Title { get; set; }
        public int Type { get; set; }
        public Course Course { get; set; }
        public int ExamId { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
        }       
    }

}
