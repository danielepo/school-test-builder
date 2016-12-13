using System;
using System.Collections.Generic;
using Entities;

namespace DAL
{
    public class QuestionRepository : IQuestionRepository
    {
        private static List<Question> questions = new List<Question>()
        {
            new Question("question1"),
            new Question("question2")
        };

        public void Add(Question q)
        {
            questions.Add(q);
        }

        public IEnumerable<Question> GetAll()
        {
            return questions;
        }
    }
}