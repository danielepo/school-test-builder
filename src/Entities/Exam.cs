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
        private IList<Question> _questions;
        public string Instructions { get; set; }

        public IEnumerable<Question> Questions => _questions;

        public string Title { get; set; }
        public int Type { get; set; }
        public Course Course { get; set; }
        public int Id { get; set; }

        public Exam()
        {
            _questions = new List<Question>();
            Course = new Course("irrilevant","irrilevant");
        }
        
        public Exam Clone(Random random)
        {
            return new Exam
            {
                Title = Title,
                Instructions = Instructions,
                _questions = Questions.Select(q => q.Clone(random)).Shuffle(random).ToList()
            };
        }

        public void Insert(Question question)
        {
            _questions.Add(question);
        }

        public void Insert(IEnumerable<Question> questions)
        {
            foreach (var question in questions)
            {
                _questions.Add(question);
            }
        }

        public void Remove(Question question)
        {
            _questions.Remove(question);
        }
    }

}
