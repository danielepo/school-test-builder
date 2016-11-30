using System.Collections.Generic;
using Entities;

namespace DAL
{
    public class QuestionRepository
    {
        private static List<Question> questions = new List<Question>()
        {
            new Question("question1"),
            new Question("question2")
        };
        
        public IEnumerable<Question> GetAll()
        {
            return questions;
        }
    }
}