using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities;
using System;

namespace BL
{
    public class DocumentGenerator
    {
        public void Create(Exam exam)
        {
            var location =  $"{AppDomain.CurrentDomain.BaseDirectory}/{exam.Title} - {exam.Type}.docx";
            using (var package = WordprocessingDocument.Create(location, WordprocessingDocumentType.Document))
            {
                var mainDocumentPart = package.AddMainDocumentPart();

                CreateDocument(exam).Save(mainDocumentPart);
            }
        }

        private Document CreateDocument(Exam exam)
        {
            var body = new Body(Title(exam.Title),
                Table(exam.Type),
                Instruction(exam.Instructions));

            foreach (var question in exam.Questions)
                AppendQuestion(body, question);

            return new Document(body);
        }
        private Table Table(int type)
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
                    FirstRow = new OnOffValue(false),
                    LastColumn = new OnOffValue(false),
                    LastRow = new OnOffValue(false),
                    NoHorizontalBand = new OnOffValue(false),
                    NoVerticalBand = new OnOffValue(false),
                });
            var grid = new TableGrid(
                new GridColumn { Width = "1256" },
                new GridColumn { Width = "2974" },
                new GridColumn { Width = "450" },
                new GridColumn { Width = "1046" },
                new GridColumn { Width = "3634" }
                );
            var table = new Table(properties, grid);
            table.Append(new TableRow(
                new TableCell(Label("Insegnate:")),
                new TableCell(Value("Settimi Maria Rosa")),
                new TableCell(Label("")),
                new TableCell(Label("Nome:")),
                new TableCell(Value(""))
                ));
            table.Append(new TableRow(
                new TableCell(Label("Variante:")),
                new TableCell(Value(type.ToString())),
                new TableCell(Label("")),
                new TableCell(Label("Classe:")),
                new TableCell(Value(""))
                ));
            table.Append(new TableRow(
                new TableCell(Label("Voto:")),
                new TableCell(Value("")),
                new TableCell(Label("")),
                new TableCell(Label("Data:")),
                new TableCell(Value(""))
                ));
            return table;
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
        private Paragraph Label(string text)
        {
            var paragraphProperties = new ParagraphProperties();
            var runProperties = new RunProperties(new FontSize { Val = "20" });
            return ParagraphFrom(text, paragraphProperties, runProperties);
        }
        private Paragraph Value(string text)
        {
            var paragraphProperties = new ParagraphProperties(new ParagraphBorders(new BottomBorder { Val = BorderValues.Single, Size = 4, Space = 3, Color = "auto" }));
            var runProperties = new RunProperties(new FontSize { Val = "20" });
            return ParagraphFrom(text, paragraphProperties, runProperties);
        }
        private void AppendQuestion(Body body, Question question)
        {
            body.Append(ParagraphFrom(question));
            var length = question.Choiches.Count;
            for (int i = 0; i < length; i++)
            {
                var answer = question.Choiches[i];
                body.Append(ParagraphFrom(answer, i != length - 1));
            }
        }

        private Paragraph ParagraphFrom(Question question)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 0 }, new NumberingId() { Val = 1 }),
                new KeepNext());
            var runProperties = new RunProperties(new FontSize() { Val = "22" });
            var extraSpace = 0;
            if (question.Space > 2)
                extraSpace = question.Space - 2;
            return ParagraphFrom(question.Text, paragraphProperties, runProperties,extraSpace);

        }
        private Paragraph ParagraphFrom(Answer answer, bool keepNext)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 1 }, new NumberingId() { Val = 1 }));
            if (keepNext)
                paragraphProperties.Append(new KeepNext());
            var runProperties = new RunProperties(new FontSize() { Val = "18" });
            return ParagraphFrom(answer.Text, paragraphProperties, runProperties);
        }
        private Paragraph ParagraphFrom(string paragraphText, ParagraphProperties paragraphProperties = null, RunProperties runProperties = null, int? breaks = 0)
        {
            var element =
                new Paragraph(paragraphProperties,
                    new Run(runProperties,
                        new Text(paragraphText))
                );
            for (int i = 0; i < breaks; i++)
                element.Append(new Break());
            return element;
        }
    }
}
