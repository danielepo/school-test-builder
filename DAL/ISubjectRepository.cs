using Entities;
using System.Collections.Generic;

namespace DAL
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();

        Subject GetByTitle(string title);
    }
}