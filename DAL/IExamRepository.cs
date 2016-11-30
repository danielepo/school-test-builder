﻿using System.Collections.Generic;
using Entities;

namespace DAL
{
    public interface IExamRepository
    {
        IEnumerable<Exam> GetAll();
        Exam GetByTitle(string title);
        void Insert(Exam exam);
    }
}