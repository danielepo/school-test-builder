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
    public class DocumentReader
    {
        public ICollection<Question> Read(int i)
        {
            var questions = new List<Question>();
            using (WordprocessingDocument package = WordprocessingDocument.Open($"C:\\Users\\m.pozzobon\\Documents\\visual studio 2015\\Projects\\QuizH\\BL\\bin\\Debug\\2016-11-22 - Educazione alimentare\\Educazione alimentare - {i}.docx", false))
            {
                MainDocumentPart mainDocumentPart = package.MainDocumentPart;

                var p = mainDocumentPart.Document.Body.ChildElements.OfType<Paragraph>().ToList();
                foreach (var x in p)
                {
                    if (x.ParagraphProperties != null && x.ParagraphProperties.NumberingProperties != null && x.ParagraphProperties.NumberingProperties.NumberingLevelReference != null)
                    {
                        if (x.ParagraphProperties.NumberingProperties.NumberingLevelReference.Val == 0)
                        {
                            questions.Add(new Question(x.InnerText));
                        }
                        else if (x.ParagraphProperties.NumberingProperties.NumberingLevelReference.Val == 1)
                            questions.Last().Add(new Answer(x.InnerText));
                    }
                }
            }
            return questions;
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
            var length = question.Choices.Count;
            for (int i = 0; i < length; i++)
            {
                var answer = question.Choices[i];
                body.Append(ParagraphFrom(answer, i != length - 1));
            }
        }

        private Paragraph ParagraphFrom(Question question)
        {
            var paragraphProperties = new ParagraphProperties(new NumberingProperties(new NumberingLevelReference() { Val = 0 }, new NumberingId() { Val = 1 }),
                new KeepNext());
            var runProperties = new RunProperties(new FontSize() { Val = "22" });
            var extraSpace = 0;
            if (question.Space > 1)
                extraSpace = question.Space - 1;
            return ParagraphFrom(question.Text, paragraphProperties, runProperties, extraSpace);
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