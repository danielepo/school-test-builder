using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Extensions
{
    public static class ExamExtensions
    {
        public static Exam Clone(this Exam exam, Random random)
        {
            return new Exam
            {
                Title = exam.Title,
                Instructions = exam.Instructions,
                Questions = exam.Questions.Select(q => q.Clone(random)).Shuffle(random).ToList()
            };
        }
        public static void Insert(this Exam exam, Question question)
        {
            exam.Questions.Add(question);
        }

        public static void Insert(this Exam exam, IEnumerable<Question> questions)
        {
            foreach (var question in questions)
            {
                exam.Questions.Add(question);
            }
        }

        public static void Remove(this Exam exam, Question question)
        {
            exam.Questions.Remove(question);
        }

    }

}
