using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Extensions;

namespace DocumentFormat.OpenXml.Extensions.Examples
{
    public partial class _Default : System.Web.UI.Page
    {
        //Example 1
        protected void Button1_Click(object sender, EventArgs e)
        {
            MemoryStream stream = SpreadsheetReader.Create();
            SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, true);
            WorksheetPart worksheetPart = SpreadsheetReader.GetWorksheetPartByName(doc, "Sheet1");
            WorksheetWriter writer = new WorksheetWriter(doc, worksheetPart);

            writer.PasteText("B2", "Hello World");

            //Save to the memory stream
            SpreadsheetWriter.Save(doc);
            
            //Write to response stream
            Response.Clear();
            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", "example1.xlsx"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            stream.WriteTo(Response.OutputStream);
            Response.End();
        }

        //Example 2
        protected void Button2_Click(object sender, EventArgs e)
        {
            MemoryStream stream = SpreadsheetReader.Create();
            SpreadsheetDocument doc = SpreadsheetDocument.Open(stream, true);
            WorksheetPart worksheetPart = SpreadsheetReader.GetWorksheetPartByName(doc, "Sheet1");
            WorksheetWriter writer = new WorksheetWriter(doc, worksheetPart);

            //Paste some text with some style
            SpreadsheetStyle style = SpreadsheetReader.GetDefaultStyle(doc);
            style.IsBold = true;
            writer.PasteText("A2", "Bold text", style);

            //Paste a numeric value and a date
            writer.PasteNumber("B2", "100");
            writer.PasteDate("C2", DateTime.Now);

            //Save to the memory stream
            SpreadsheetWriter.Save(doc);

            //Write to response stream
            Response.Clear();
            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", "example2.xlsx"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            stream.WriteTo(Response.OutputStream);
            Response.End();
        }
    }
}
