using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BL;
namespace BL.Test
{
    class HtmlParserTest
    {
        [TestCase("text", "text")]
        [TestCase("<div>text</div>", "text")]
        [TestCase("<p>text</p>", "text")]
        [TestCase("<div>text</div> other", "text other")]
        public void Test(string html, string expected)
        {
            var parser = new HtmlStringParser();
            Assert.That(parser.Parse(html), Is.EqualTo(expected));
        }
        [TestCase("text", "<w:t xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\">text</w:t>")]
        [TestCase("<p>text</p>", "<w:p xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\"><w:t>text</w:t></w:p>")]
        public void TestDocument(string html, string expected)
        {
            var parser = new HtmlOpenXmlParser();
            var p = parser.Parse(html);
            Assert.That(p.OuterXml, Is.EqualTo(expected));
        }
    }
}

