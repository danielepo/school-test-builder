using System.IO;

namespace BL
{
    public class FileData
    {

        public FileData(string name, Stream stream)
        {
            Name = name;
            Stream = stream;
        }

        public string Name { get; internal set; }
        public Stream Stream { get; internal set; }
    }
}