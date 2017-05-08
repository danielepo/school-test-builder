using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();

        Subject GetByTitle(string title);
        Subject GetById(int subjectId);
        Task Insert(Subject subject);
    }
}