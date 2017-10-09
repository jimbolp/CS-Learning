using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Epplus_tests
{
    partial class Program
    {
        public static void UpdateExcelUsingEPPlus(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            ExcelPackage p = new ExcelPackage(fileInfo);

            // access the first sheet named Sheet1
            ExcelWorksheet myWorksheet = p.Workbook.Worksheets[1];
            myWorksheet.Select(myWorksheet.Dimension.Address);
            UpdateCells(myWorksheet, p);
            string chartName = "chart";
            //myWorksheet.PrinterSettings.Orientation = eOrientation.Landscape;
            //System.Xml.XmlDocument xmlDoc = myWorksheet.WorksheetXml;

            // specify cell values to be used for generating chart.
            /*myWorksheet.Cells["B2"].Value = 10;
            myWorksheet.Cells["B3"].Value = 40;
            myWorksheet.Cells["B4"].Value = 30;

            myWorksheet.Cells["A2"].Value = "Yes";
            myWorksheet.Cells["A3"].Value = "No";
            myWorksheet.Cells["A4"].Value = "NA";//*/

            // add chart of type Line.
            if (myWorksheet.Drawings.Any(d => d.Name == chartName))
                myWorksheet.Drawings.Remove(myWorksheet.Drawings.Where(d => d.Name == chartName).FirstOrDefault());
            var myChart = myWorksheet.Drawings.AddChart(chartName, eChartType.Line);
            myChart.Legend.Remove();
            // Define series for the chart
            var series = myChart.Series.Add("B2:B12", "A2:A12");
            //myChart.Border.Fill.Color = System.Drawing.Color.Green;
            myChart.Title.Text = myWorksheet.Name;
            myChart.SetSize(867, 521);

            // Add to 6th row and to the 6th column
            myChart.SetPosition(6, 0, 6, 0);

            p.Save();

        }
        public static void UpdateCells(ExcelWorksheet ws, ExcelPackage p)
        {
            string usedCells = ws.Dimension.Address;
            ExcelRange usedRange = ws.Cells[usedCells];
            int rows = usedRange.Rows;
            //usedRange.Style.QuotePrefix = false;
            var tempList = ws.Cells.Where(c => isDateTime(c.Value.ToString()));
            foreach (var cell in tempList)
            {
                //cell.Style.QuotePrefix = true;
                DateTime dt = new DateTime();
                if (DateTime.TryParse(cell.Value.ToString(), out dt))
                    cell.Value = dt.ToString("dd.MM.yyyy HH:MM");
            }
            p.Save();
        }
        private static bool isDateTime(string d)
        {
            if (DateTime.TryParse(d, out DateTime dt))
            {
                return true;
            }
            return false;
        }
    }
}
