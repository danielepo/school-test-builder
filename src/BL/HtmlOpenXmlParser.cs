using System.Net;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlAgilityPack;

namespace BL
{
    public class HtmlOpenXmlParser
    {
        public OpenXmlElement Parse(string html, RunProperties runProperties = null)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);

            var node = document.DocumentNode.FirstChild;
            //if (node.Name == "p")
            var text = string.Empty;
            if (node != null)
                text = node.InnerText;
            text = WebUtility.HtmlDecode(text);
            var run = new Run(new Text(text));
            if (runProperties != null)
                run.PrependChild(runProperties);
            return new Paragraph(run);
            //return new Text(node.InnerText);
        }
    }
}