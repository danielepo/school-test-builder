using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Exam
    {
        public string Instructions { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public string Title { get; set; }
    }
}
