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

        public List<Question> Questions { get; set; } = new List<Question>();
        public string Title { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; } = new Course();

    }

}
