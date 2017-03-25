using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BL
{
    public class DocumentGenerator
    {
        public void Create(int type, Exam exam)
        {
            var location = $"{AppDomain.CurrentDomain.BaseDirectory}/{exam.Title} - {type}.docx";
            using (var package = WordprocessingDocument.Create(location, WordprocessingDocumentType.Document))
            {
                var mainDocumentPart = package.AddMainDocumentPart();

                CreateDocument(type, exam).Save(mainDocumentPart);
            }
        }
        public Stream GetStream(int type, Exam exam)
        {
            var stream = new MemoryStream();
            using (var package = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
            {
                var mainDocumentPart = package.AddMainDocumentPart();

                CreateDocument(type, exam).Save(mainDocumentPart);
            }
            return stream;
        }
        private Document CreateDocument(int type, Exam exam)
        {
            var body = new Body(Title(exam.Title),
                Table(type),
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
            var paragraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center }, new SpacingBetweenLines { Before = "0", After = "240" });
            var runProperties = new RunProperties(new FontSize { Val = "28" }, new Kern { Val = 28 }, new FontSizeComplexScript { Val = "56" }, new Bold());
            return ParagraphFrom(text, paragraphProperties, runProperties);
        }

        private Paragraph Instruction(string text)
        {
            var paragraphProperties = new ParagraphProperties(new ParagraphBorders(new BottomBorder { Val = BorderValues.Single, Size = 4, Space = 3, Color = "auto" }),
                 new SpacingBetweenLines { Before = "200", After = "200", LineRule = LineSpacingRuleValues.Auto });
            var runProperties = new RunProperties(new FontSize { Val = "20" }, new Italic());
            return ParagraphFrom(text, paragraphProperties, runProperties);
        }

        private Paragraph Label(string text, bool keepNext = false)
        {
            var paragraphProperties = new ParagraphProperties(new SpacingBetweenLines { Before = "0", After = "25", LineRule = LineSpacingRuleValues.Auto });
            if (keepNext)
                paragraphProperties.Append(new KeepNext());
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
                body.Append(ParagraphFrom(answer,i, i != length - 1));
            }
        }

        private Table TableChoiches(ICollection<Answer> choiches)
        {
            var properties = new TableProperties(
                //new TableIndentation { Width = 720, Type = TableWidthUnitValues.Dxa },
                new TableWidth { Type = TableWidthUnitValues.Pct, Width = "5000" },
                new TableLayout { Type = TableLayoutValues.Fixed },
                new TableCellMargin
                {
                    TopMargin = new TopMargin { Width = "0", Type = TableWidthUnitValues.Dxa },
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
                new GridColumn { Width = "4096" },
                new GridColumn { Width = "4096" }
                );
            var table = new Table(properties, grid);
            TableRow row = null;
            for (int i = 0; i < choiches.Count; i++)
            {
                if (i % 2 == 0)
                {
                    if (row != null)
                        table.Append(row);
                    row = new TableRow();
                }
                row.Append(new TableCell(ParagraphFrom(choiches.ElementAt(i), i, i < choiches.Count - 2)));
                //row.Append(new TableCell(Label("    " + (i + 1) + ". " + choiches.ElementAt(i).Text, i < choiches.Count - 2)));
            }
            if (row != null)
                table.Append(row);
            return table;
        }

        private Paragraph ParagraphFrom(Question question)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 0 }, new NumberingId() { Val = 1 }),
                new SpacingBetweenLines { Before = "75", After = "0", LineRule = LineSpacingRuleValues.Auto },
                new KeepNext());
            var runProperties = new RunProperties(new FontSize() { Val = "22" });
            var extraSpace = 0;
            if (question.Space > 1)
                extraSpace = question.Space - 1;
            return ParagraphFrom(question.Text, paragraphProperties, runProperties, extraSpace);
        }

        private Paragraph ParagraphFrom(Answer answer, int index, bool keepNext)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 1 }, new NumberingId() { Val = 1 }),
                new SpacingBetweenLines { Before = "0", After = "0", LineRule = LineSpacingRuleValues.Auto });
            if (keepNext)
                paragraphProperties.Append(new KeepNext());
            var runProperties = new RunProperties(new FontSize() { Val = "22" });
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