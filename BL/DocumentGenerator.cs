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
        public void Create(Exam exam)
        {
            using (WordprocessingDocument package = WordprocessingDocument.Create(@"C:\Users\m.pozzobon\Documents\visual studio 2015\Projects\QuizH\BL\bin\Debug\TestDocument.docx", WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainDocumentPart = package.AddMainDocumentPart();

                Document document = CreateDocument(exam);
                document.Save(mainDocumentPart);
            }
        }

        private Document CreateDocument(Exam exam)
        {
            var body = new Body(Title(exam.Title),Table(),Instruction(exam.Instructions));

            foreach (var question in exam.Questions)
                AppendQuestion(body, question);

            return new Document(body);
        }
        private Table Table()
        {
            var properties = new TableProperties(
                new TableWidth { Type = TableWidthUnitValues.Pct, Width = "5000" }, 
                new TableLayout { Type = TableLayoutValues.Fixed },
                new TableCellMargin
                {
                    TopMargin = new TopMargin { Width = "115", Type = TableWidthUnitValues.Dxa },
                    LeftMargin = new LeftMargin { Width = "0", Type = TableWidthUnitValues.Dxa },
                    RightMargin = new RightMargin { Width = "0", Type = TableWidthUnitValues.Dxa }
                },
                new TableLook
                {
                    Val = "0000",
                    FirstColumn = new OnOffValue(false),
                    FirstRow= new OnOffValue(false),
                    LastColumn = new OnOffValue(false),
                    LastRow = new OnOffValue(false),
                    NoHorizontalBand = new OnOffValue(false),
                    NoVerticalBand = new OnOffValue(false),
                });
            var grid = new TableGrid(
                new GridColumn { Width = "1256"},
                new GridColumn { Width = "2974"},
                new GridColumn { Width = "450"},
                new GridColumn { Width = "1046"},
                new GridColumn { Width = "3634"}
                );
            var table = new Table(properties, grid);
            return null;
        }
        private Paragraph Title(string text)
        {
            var paragraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center }, new SpacingBetweenLines { Before = "120", After = "360" });
            var runProperties = new RunProperties(new FontSize { Val = "28" }, new Kern { Val = 28 }, new FontSizeComplexScript { Val = "56" }, new Bold());
            return ParagraphFrom(text, paragraphProperties, runProperties);
        }
        private Paragraph Instruction(string text)
        {
            var paragraphProperties = new ParagraphProperties(new ParagraphBorders(new BottomBorder { Val = BorderValues.Single, Size = 4, Space = 3, Color = "auto" }),
                 new SpacingBetweenLines { Before = "400", After = "240", LineRule = LineSpacingRuleValues.Auto });
            var runProperties = new RunProperties(new FontSize { Val = "20" }, new Italic());
            return ParagraphFrom(text, paragraphProperties, runProperties);
        }
        private void AppendQuestion(Body body, Question question)
        {
            body.Append(ParagraphFrom(question));
            foreach (var answer in question.Answers)
                body.Append(ParagraphFrom(answer));
        }

        private Paragraph ParagraphFrom(Question question)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 0 }, new NumberingId() { Val = 1 }));
            var runProperties = new RunProperties(new FontSize() { Val = "22" });
            return ParagraphFrom(question.Text, paragraphProperties, runProperties);

        }
        private Paragraph ParagraphFrom(Answer answer)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 1 }, new NumberingId() { Val = 1 }));
            var runProperties = new RunProperties(new FontSize() { Val = "18" });
            return ParagraphFrom(answer.Text, paragraphProperties, runProperties);
        }
        private Paragraph ParagraphFrom(string paragraphText, ParagraphProperties paragraphProperties = null, RunProperties runProperties = null)
        {
            var element =
                new Paragraph(paragraphProperties,
                    new Run(runProperties,
                        new Text(paragraphText))
                );
            return element;
        }
    }
}
