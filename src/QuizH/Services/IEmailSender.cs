using System.Threading.Tasks;

namespace QuizH.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
