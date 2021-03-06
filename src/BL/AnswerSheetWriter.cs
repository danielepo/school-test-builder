﻿using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AnswerSheetWriter
    {
        public void Create(IEnumerable<IEnumerable<string>> answers)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet 1");
            AddContent(1, 1, worksheet, answers);
            var location = $"{AppDomain.CurrentDomain.BaseDirectory}/risposte.xlsx";
            workbook.SaveAs(location);
        }
        public Stream GetStream(IEnumerable<IEnumerable<string>> answers)
        {
            var stream = new MemoryStream();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet 1");
            AddContent(1, 1, worksheet, answers);
            workbook.SaveAs(stream);
            return stream;
        }
        protected void AddContent(int startRow, int startColumn, IXLWorksheet worksheet, IEnumerable<IEnumerable<string>> data)
        {
            var row = startRow;
            var column = startColumn;
            foreach (var rowData in data)
            {
                row = startRow;
                foreach (var value in rowData)
                {
                    var cell = worksheet.Cell(row, column);
                    cell.Value = "'" + value;
                    row++;
                }
                column++;
            }
        }


    }
}
