using System.Linq;
using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class QuestionRepository : IQuestionRepository
    {
        private static List<Question> questions = new List<Question>();
        private EntityDbContext context;
        public QuestionRepository(EntityDbContext context)
        {
            this.context = context;
        }
        public void Add(Question q)
        {
            context.Questions.Add(q);
            context.SaveChanges();
        }

        public IEnumerable<Question> GetAll()
        {
            return context.Questions
                .Include(questions => questions.Choiches)
                .Include(x=>x.Courses);
        }

        public Question GetById(int questionId)
        {
            return context.Questions
                .Include(questions => questions.Choiches)
                .Include(x => x.Courses)
                .FirstOrDefault(q => q.QuestionId == questionId);
        }

        public void Update(Question oldQuestion, Question newQuestion)
        {
            oldQuestion.Choiches = newQuestion.Choiches;
            oldQuestion.Text = newQuestion.Text;
            oldQuestion.Professor = newQuestion.Professor;
            oldQuestion.ProfessorId = newQuestion.ProfessorId;
            oldQuestion.Space= newQuestion.Space;
            oldQuestion.Subject= newQuestion.Subject;
            oldQuestion.SubjectId= newQuestion.SubjectId;
            oldQuestion.Courses= newQuestion.Courses;

            context.Questions.Update(oldQuestion);
            
            context.SaveChanges();
        }
    }

}