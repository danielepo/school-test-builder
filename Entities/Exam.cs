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
        public string Instructions { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public string Title { get; set; }

        public Exam Clone(Random random)
        {
            return new Exam()
            {
                Title = Title,
                Instructions = Instructions,
                Questions = Questions.Select(q => q.Clone(random)).Shuffle(random)
            };
        }
    }

}
