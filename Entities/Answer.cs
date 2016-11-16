using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Answer
    {

        public Answer(string value)
        {
            Text = value;
        }

        public string Text { get; set; }
    }
}
