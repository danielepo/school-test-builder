using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities;
using System.Text;
using NotesFor.HtmlToOpenXml;
namespace BL
{
    public class DocumentGenerator
    {
        private readonly HtmlStringParser stringParser = new HtmlStringParser();
        private readonly HtmlOpenXmlParser oxmlParser = new HtmlOpenXmlParser();
        public Professor professor { get; set; }

        public Stream GetStream(int type, Exam exam)
        {
            var stream = new MemoryStream();
            using (var package = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
            {
                var mainDocumentPart = package.AddMainDocumentPart();

                CreateDocument2(type, exam, mainDocumentPart).Save(mainDocumentPart);
            }
            return stream;
        }

        private Document CreateDocument(int type, Exam exam)
        {
            var body = new Body(Title(exam.Title),
                Table(type, professor),
                Instruction(exam.Instructions ?? ""));

            foreach (var question in exam.Questions)
                AppendQuestion(body, question);

            return new Document(body);
        }

        private Document CreateDocument2(int type, Exam exam, MainDocumentPart part)
        {
            var head = $"<head><title>{exam.Title}</title></head>";
            var table = $@"<table width='100%' border='1'><tbody>
                <tr><td width='13%'>Insegnate:</td><td width='32%'>{professor?.Name} {professor?.Surname}</td></td><td width='16%'>Nome: </td><td width='39%'></td></tr>
                <tr><td width='13%'>Variante:</td><td width='32%'>{type}</td><td width='16%'>Classe:</td><td width='39%'></td></tr>
                <tr><td width='13%'>Voto:</td><td width='32%'></td><td width='16%'>Data:</td><td width='39%'></td></tr>
                </tbody></table>";
            var instructions = $"<div>{exam.Instructions}</div>";
            StringBuilder questions = new StringBuilder();

            foreach (var question in exam.Questions)
            {
                questions.Append("<div>");
                questions.Append(question.Text);
                if (question.Choiches.Any())
                {
                    questions.Append("<ol>");
                    foreach (var choice in question.Choiches)
                    {
                        questions.Append($"<li>{choice.Text}</li>");
                    }
                    questions.Append("</ol>");
                }
                else
                {
                    questions.Append("<table><tbody>");
                    for (var i = 0; i < question.Space; i++)
                    {
                        questions.Append($"<tr><td></td><tr>");
                    }
                    questions.Append("</tbody></table>");
                }

            }
            var document = $"<html>{head}<body>{table}{instructions}{questions.ToString()}</body></html>";

            HtmlConverter converter = new HtmlConverter(part);
            converter.ImageProcessing = ImageProcessing.ManualProvisioning;
            //converter.BaseImageUrl = new Uri();
            converter.ProvisionImage += (sender, e) =>
            {
                var imageUrl = e.ImageUrl;
                e.Provision(File.ReadAllBytes(@"wwwroot"+imageUrl));
            };
            converter.ParseHtml(document);
            return part.Document;
        }
        protected Table Table(int type, Professor professor)
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
                    NoVerticalBand = new OnOffValue(false)
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
                new TableCell(Value($"{professor?.Name} {professor?.Surname}")),
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
                body.Append(ParagraphFrom(answer, i != length - 1));
            }
        }

        private Paragraph ParagraphFrom(Question question)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference { Val = 0 }, new NumberingId { Val = 1 }),
                new SpacingBetweenLines { Before = "75", After = "0", LineRule = LineSpacingRuleValues.Auto },
                new KeepNext());
            var runProperties = new RunProperties(new FontSize { Val = "22" });
            var extraSpace = 0;
            if (question.Space > 1)
                extraSpace = question.Space - 1;
            return ParagraphFrom(question.Text, paragraphProperties, runProperties, extraSpace);
        }

        private Paragraph ParagraphFrom(Answer answer, bool keepNext)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference { Val = 1 }, new NumberingId { Val = 1 }),
                new SpacingBetweenLines { Before = "0", After = "0", LineRule = LineSpacingRuleValues.Auto });
            if (keepNext)
                paragraphProperties.Append(new KeepNext());
            var runProperties = new RunProperties(new FontSize { Val = "22" });
            return ParagraphFrom(answer.Text, paragraphProperties, runProperties);
        }

        private Paragraph ParagraphFrom(string paragraphText, ParagraphProperties paragraphProperties = null, RunProperties runProperties = null, int? breaks = 0)
        {
            //var text = stringParser.Parse(paragraphText);
            //var element =
            //    new Paragraph(paragraphProperties,
            //        new Run(runProperties,
            //            new Text(text))
            //    );
            var element = oxmlParser.Parse(paragraphText, runProperties);
            element.PrependChild(paragraphProperties);
            if (breaks > 0)
            {
                element.Append(new Break());
                element.Append(TableBreak(breaks));
            }
            return (Paragraph)element;
        }

        private Table TableBreak(int? breaks)
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
                                NoVerticalBand = new OnOffValue(false)
                            });
            var grid = new TableGrid(
                new GridColumn { Width = "1256" });
            var table = new Table(properties, grid);
            while (breaks >= 0)
            {
                table.Append(new TableRow(new TableCell(Value(""))));
                breaks--;
            }
            return table;
        }
    }
}