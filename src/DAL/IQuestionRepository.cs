using System.Collections.Generic;
using Entities;

namespace DAL
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
        void Add(Question q);
    }
}