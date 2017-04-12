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

    }

}
