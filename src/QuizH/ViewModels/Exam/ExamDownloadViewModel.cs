using System.IO;

namespace QuizH.ViewModels.Exam
{
    public class ExamDownloadViewModel
    {
        public Stream Stream { get; internal set; }
        public string FileName { get; internal set; }
    }
}