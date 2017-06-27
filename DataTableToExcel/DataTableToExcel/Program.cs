using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;
using DataTable = System.Data.DataTable;
using OfficeOpenXml;
using System.Net.Mail;
using System.Net;

namespace DataTableToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            SendEmailWithExcelAttachment(table);
        }
        public static void SendEmailWithExcelAttachment(DataTable dt)
        {
            try
            {
                //string smptHost = smptTuple.Item1;

                MailAddress From = new MailAddress("jimbolp@gmail.com", "Yavor Georgiev");
                MailAddress To = new MailAddress("f.meranzova@phoenixpharma.bg", "Fina Meranzova");
                const string subj = "some subj";
                const string body = "some body";
                const string pass = "j0lym0ly32";

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(From.Address, pass),
                    Timeout = 20000
                };
                
                string temp = Path.GetTempPath(); // Get %TEMP% path
                string file = "fileNameHere.xlsx";
                string path = Path.Combine(temp, file); // Get the whole path

                FileInfo fi = new FileInfo(path);
                using (ExcelPackage pck = new ExcelPackage(fi))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Table");
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    pck.Save();
                    //string debugStr = pck.File.FullName;
                    //mailMsg.Attachments.Add(new Attachment(path, "application/vnd.ms-excel"));
                    
                    using (var message = new MailMessage(From, To)
                    {
                        Subject = subj,
                        Body = body
                    })
                    {
                        /*FileStream fs = fi.Create();
                        byte[] arr = pck.GetAsByteArray();

                        fs.Read(arr, 0, arr.Length);//*/
                        
                        //StreamReader sr = new StreamReader(fs);

                        message.Attachments.Add(new Attachment(path, "application/vnd.ms-excel"));
                        try
                        {
                            smtp.Send(message);
                        }
                        catch (Exception)
                        {
                            //do smth..
                        }
                        finally
                        {
                            fi.Delete();
                            
                            //File.Delete(path);
                        }
                    }
                    pck.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private static byte[] GetData(DataTable dt)
        {
            string strBody = DataTable2ExcelString(dt);
            byte[] data = Encoding.ASCII.GetBytes(strBody);
            return data;
        }

        private static string DataTable2ExcelString(DataTable dt)
        {

            string excelSheetName = "Sheet1";
            StringBuilder sbTop = new StringBuilder();
            sbTop.Append("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" ");
            sbTop.Append("xmlns=\" http://www.w3.org/TR/REC-html40\"><head><meta http-equiv=Content-Type content=\"text/html; charset=windows-1252\">");
            sbTop.Append("<meta name=ProgId content=Excel.Sheet ><meta name=Generator content=\"Microsoft Excel 9\"><!--[if gte mso 9]>");
            sbTop.Append("<xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>" + excelSheetName + "</x:Name><x:WorksheetOptions>");
            sbTop.Append("<x:Selected/><x:ProtectContents>False</x:ProtectContents><x:ProtectObjects>False</x:ProtectObjects>");
            sbTop.Append("<x:ProtectScenarios>False</x:ProtectScenarios></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets>");
            sbTop.Append("<x:ProtectStructure>False</x:ProtectStructure><x:ProtectWindows>False</x:ProtectWindows></x:ExcelWorkbook></xml>");
            sbTop.Append("<![endif]-->");
            sbTop.Append("</head><body><table>");

            string bottom = "</table></body></html>";


            StringBuilder sbHeader = new StringBuilder();

            //Header
            sbHeader.Append("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sbHeader.Append("<td>" + dt.Columns[i].ColumnName + "</td>");
            }
            sbHeader.Append("</tr>");

            //Items
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                sbHeader.Append("<tr>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sbHeader.Append("<td>" + dt.Rows[x][i] + "</td>");
                }
                sbHeader.Append("</tr>");
            }

            string data = sbTop.ToString() + sbHeader.ToString() + bottom;

            return data;
        }
    }
}
