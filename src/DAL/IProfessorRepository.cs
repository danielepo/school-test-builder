using System.Collections.Generic;
using Entities;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProfessorRepository
    {
        IEnumerable<Professor> GetAll();
        Professor GetById(string id);
        void Insert(Professor prof);
        Task Update(Professor prof);
    }
}