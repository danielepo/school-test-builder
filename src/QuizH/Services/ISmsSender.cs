using System.Threading.Tasks;

namespace QuizH.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
