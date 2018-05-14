using Limilabs.Client.SMTP;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Epplus_tests
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Documents\Dixel Graphics\Sofia\Book1.xlsx";
            //string path = @"D:\Documents\Dixel Graphics\Sofia\tests.xlsx";
            try
            {
                var test = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                Console.WriteLine(test.EvaluationContext);
            }
            catch(ConfigurationException ex)
            {
                string fileName = ex.Filename;
                string description = ex.BareMessage;
            }
            //UpdateExcelUsingEPPlus(path);
        }
        public static void SendEmailWithExcelAttachment(DataTable dt, Tuple<string> smtpTuple)
        {
            try
            {
                string smtpHost = smtpTuple.Item1;
                MailMessage mailMsg = new MailMessage();
                SmtpClient smtp = new SmtpClient(smtpHost);

                string temp = Path.GetTempPath(); // Get %TEMP% path
                string file = "fileNameHere.xlsx";
                string path = Path.Combine(temp, file); // Get the whole path to the file

                FileInfo fi = new FileInfo(path);
                using (ExcelPackage pck = new ExcelPackage(fi))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Table");
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    pck.Save();
                }
                mailMsg.Attachments.Add(new System.Net.Mail.Attachment(path, "application/vnd.ms-excel"));
                try
                {
                    //send email
                    smtp.Send(mailMsg);
                }
                catch (Exception)
                {
                    //do smth..
                }
                finally
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
