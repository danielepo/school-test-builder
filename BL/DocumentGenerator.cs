using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DocumentGenerator
    {
        public void Generate(IEnumerable<Question> questions)
        {
            using (WordprocessingDocument package = WordprocessingDocument.Create(@"C:\Users\m.pozzobon\Documents\visual studio 2015\Projects\QuizH\BL\bin\Debug\TestDocument.docx", WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainDocumentPart = package.AddMainDocumentPart();

                var body = new Body(
                    GenerateParagraph("Welcome to my test document."),
                    GenerateParagraph("I generated this with help from the Open XML DocumentReflector."),
                    GenerateParagraph("What a great tool!"));
                foreach (var question in questions)
                {
                    body.Append(GenerateIndented(question.Text, true));
                    foreach (var answer in question.Answers)
                    {
                        body.Append(GenerateIndented(answer.Text, false));
                    }
                }
                Document document = new Document(body);
                document.Save(mainDocumentPart);
            }
        }

        public static Paragraph GenerateIndented(string paragraphText, bool isQuestion)
        {
            var paragraphProperties = isQuestion ?
                new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 0 }, new NumberingId() { Val = 1 }))
                : new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 1 }, new NumberingId() { Val = 1 }));
            var runProperties = isQuestion ?
                new RunProperties(new FontSize() { Val = "22" })
                : new RunProperties(new FontSize() { Val = "18" });
            var element =
                new Paragraph(paragraphProperties,
                    new Run(runProperties,
                        new Text(paragraphText))
                );
            return element;
        }
        public static Paragraph GenerateParagraph(string paragraphText)
        {
            var element =
                new Paragraph(
                    new Run(
                        new Text(paragraphText))
                );
            return element;
        }
    }
}
