using System.Linq;
using System.Collections.Generic;
using Entities;
using System;

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

        public Question GetById(int questionId)
        {
            return questions.FirstOrDefault(q => q.Id == questionId);
        }

        public void Update(Question oldQuestion, Question newQuestion)
        {
            questions.Remove(oldQuestion);
            newQuestion.Id = oldQuestion.Id;
            questions.Add(newQuestion);
        }
    }

}