using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlAgilityPack;
using NUnit.Framework;

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

    internal class HtmlOpenXmlParser
    {
        public OpenXmlElement Parse(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);

            var node = document.DocumentNode.FirstChild;
            if (node.Name == "p")
                return new Paragraph(new Text(node.InnerText));
            return new Text(node.InnerText);
        }
    }

    internal class HtmlStringParser
    {
        public string Parse(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            return document.DocumentNode.InnerText;
        }
    }
}
