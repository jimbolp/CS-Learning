using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Epplus_tests
{
    partial class Program
    {
        public static void UpdateExcelUsingEPPlus(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            ExcelPackage p = new ExcelPackage(fileInfo);

            // access the first sheet named Sheet1
            ExcelWorksheet myWorksheet = p.Workbook.Worksheets["Sheet1"];

            // specify cell values to be used for generating chart.
            myWorksheet.Cells["C2"].Value = 10;
            myWorksheet.Cells["C3"].Value = 40;
            myWorksheet.Cells["C4"].Value = 30;

            myWorksheet.Cells["B2"].Value = "Yes";
            myWorksheet.Cells["B3"].Value = "No";
            myWorksheet.Cells["B4"].Value = "NA";

            // add chart of type Pie.
            var myChart = myWorksheet.Drawings.AddChart("chart", eChartType.Line);

            // Define series for the chart
            var series = myChart.Series.Add("C2:C4", "B2:B4");
            myChart.Border.Fill.Color = System.Drawing.Color.Green;
            myChart.Title.Text = "My Chart";
            myChart.SetSize(400, 400);

            // Add to 6th row and to the 6th column
            myChart.SetPosition(6, 0, 6, 0);

            p.Save();

        }
    }
}
