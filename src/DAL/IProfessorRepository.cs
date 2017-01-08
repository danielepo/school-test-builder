using System.Collections.Generic;
using Entities;

namespace DAL
{
    public interface IProfessorRepository
    {
        IEnumerable<Professor> GetAll();
        Professor GetById(string id);
        void Insert(Professor prof);
    }
}