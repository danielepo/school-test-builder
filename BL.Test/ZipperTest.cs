using DocumentFormat.OpenXml.Packaging;
using Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace BL.Test
{
    public class ZipperTest
    {
        [Test]
        public void Zip_DoesNotReturnNull()
        {
            var zipper = new Zipper();
            var streams = new List<FileData>();
            var stream = zipper.Zip(streams);
            Assert.That(stream, Is.Not.Null);
        }
        [Test]
        public void Zip()
        {
            var zipper = new Zipper();
            var files = new List<FileData>()
            {
                new FileData("titolo.docx", new DocumentGenerator().GetStream(1, new Exam{ Title = "Titolo", Instructions = "ins"}))
            };
            var stream = zipper.Zip(files);
            var zip = new ZipArchive(stream, ZipArchiveMode.Read);
            Assert.That(zip.Entries.Count, Is.EqualTo(1));
        }
    }
}