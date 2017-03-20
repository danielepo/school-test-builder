using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    public class Zipper
    {
        public Stream Zip(List<FileData> files)
        {
            var zipStream = new MemoryStream();
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var file in files)
                {
                    var stream = file.Stream;
                    var demoFile = archive.CreateEntry(file.Name);

                    using (var entryStream = demoFile.Open())
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.CopyTo(entryStream);
                    }
                }
            }
            return zipStream;
        }
    }
}
