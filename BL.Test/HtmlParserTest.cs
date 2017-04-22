using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BL;

namespace BL.Test
{
    internal class HtmlParserTest
    {
        [TestCase("text", "text")]
        [TestCase("&agrave;", "à")]
        [TestCase("<div>text</div>", "text")]
        [TestCase("<p>text</p>", "text")]
        [TestCase("<div>text</div> other", "text other")]
        public void ParseToNormalString(string html, string expected)
        {
            var parser = new HtmlStringParser();
            Assert.That(parser.Parse(html), Is.EqualTo(expected));
        }

        [TestCase("", "<w:p xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\"><w:r><w:t /></w:r></w:p>")]
        [TestCase("text", "<w:p xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\"><w:r><w:t>text</w:t></w:r></w:p>")]
        [TestCase("citt&agrave;", "<w:p xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\"><w:r><w:t>città</w:t></w:r></w:p>")]
        [TestCase("<p>text</p>", "<w:p xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\"><w:r><w:t>text</w:t></w:r></w:p>")]
        public void ParseToOOXML(string html, string expected)
        {
            var parser = new HtmlOpenXmlParser();
            var p = parser.Parse(html);
            Assert.That(p.OuterXml, Is.EqualTo(expected));
        }
    }
}