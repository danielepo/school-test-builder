using System.Net;
using HtmlAgilityPack;

namespace BL
{
    public class HtmlStringParser
    {
        public string Parse(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            return WebUtility.HtmlDecode(document.DocumentNode.InnerText);
        }
    }
}