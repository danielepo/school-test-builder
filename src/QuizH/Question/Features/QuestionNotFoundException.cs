using System;
using System.Runtime.Serialization;

namespace QuizH.Features.Question
{
    [Serializable]
    public class QuestionNotFoundException : Exception
    {
        public QuestionNotFoundException()
        {
        }

        public QuestionNotFoundException(string message) : base(message)
        {
        }

        public QuestionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QuestionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}