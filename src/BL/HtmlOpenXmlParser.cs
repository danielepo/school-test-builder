using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlAgilityPack;

namespace BL
{
     public class HtmlOpenXmlParser
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
}