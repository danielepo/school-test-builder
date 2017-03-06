using System;
using System.Collections.Generic;
using Entities;

namespace DAL
{
    public class QuestionRepository : IQuestionRepository
    {
        private static List<Question> questions = new List<Question>();
        
        public void Add(Question q)
        {
            q.Id = questions.Count;
            questions.Add(q);
        }

        public IEnumerable<Question> GetAll()
        {
            return questions;
        }
    }

}