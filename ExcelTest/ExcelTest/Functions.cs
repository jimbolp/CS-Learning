using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ConvertPZN
{
    partial class Form1
    {
        public Workbook LoadXlFile(Application xlApp, string fileName)
        {
            Workbook xlWorkbook;
            try
            {
                xlWorkbook = xlApp.Workbooks.Open(fileName, ReadOnly: false, Format: 5,
                    IgnoreReadOnlyRecommended: true,
                    Origin: XlPlatform.xlWindows, Delimiter: "\t", Editable: true, Notify: true, AddToMru: false,
                    Local: 1, CorruptLoad: 0);
            }
            //catch 1...
            catch (COMException exception)
            {
                File.AppendAllText("log.txt", new string('-', 80) +
                    Environment.NewLine +
                    DateTime.Now +
                    Environment.NewLine +
                    exception.Message +
                    Environment.NewLine + 
                    exception.StackTrace);
                //catch me if you can... **Any similarity with a "movie" or whatever is only in your mind**
                throw new COMException("Невалиден файл!");
            }
            return xlWorkbook;
        }
        private void OpenFileAndDoStuff()
        {
            startReplacing.Enabled = false;
            if (filePathTextBox.Text == BLANK_TEXT_BOX || filePathTextBox.Text.Trim() == "")
            {
                ExceptionLabel.Text = "Преди да стартирате, заредете файла за обработка.";
                return;
            }

            Cursor = Cursors.WaitCursor;
            ExceptionLabel.Text = "Файлът се отваря....";
            var xlApp = new Application();
            string fileName = filePathTextBox.Text;
            filePathTextBox.Text = "";
            try
            {
                var xlWorkBook = LoadXlFile(xlApp, fileName);
                
                Worksheet xlWorkSheet = (Worksheet) xlWorkBook.ActiveSheet;
                xlWorkSheet.UsedRange.AutoFormat(Border:false);
                Range range = xlWorkSheet.UsedRange; //.AutoFormat();

                //xlWorkSheet.UsedRange.Rows.AutoFormat();
                //xlWorkSheet.UsedRange.Columns.AutoFormat();
                int rowsRange = range.Rows.Count;
                int colsRange = range.Columns.Count;
                
                ConvertPZN(rowsRange, range);

                AddBorders(rowsRange, colsRange, range);

                range.Columns.AutoFit();

                xlWorkBook.Save();
                if (xlWorkBook.Saved)
                    ExceptionLabel.Text = FILE_SAVED;
                else
                {
                    ExceptionLabel.Text = FILE_NOT_SAVED +
                                          Environment.NewLine +
                                          "Проверете дали файла не се използва от друго приложение.";
                }
                xlWorkBook.Close(false);
                xlApp.Quit();

                Cursor = DefaultCursor;
                Marshal.ReleaseComObject(xlApp);
            }
                //catch 2...
            catch (COMException ce)
            {
                ExceptionLabel.Text = FILE_NOT_FOUND +
                                      Environment.NewLine +
                                      ce.Message;
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                Cursor = DefaultCursor;

                System.Windows.Forms.Application.DoEvents();
                startReplacing.Enabled = true;
            }
                //catch 3...
            catch (FileNotFoundException exception)
            {
                ExceptionLabel.Text = FILE_NOT_FOUND +
                                      Environment.NewLine +
                                      exception.Message;
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                Cursor = DefaultCursor;
                System.Windows.Forms.Application.DoEvents();
                startReplacing.Enabled = true;
            }
                //catch that shit already.. 
            catch (Exception exception)
            {
                if (exception.Message.Contains("We can't save"))
                    ExceptionLabel.Text = "Файлът не може да бъде запаметен, защото се използва." +
                                          Environment.NewLine +
                                          "Моля затворете файла и опитайте отново";
                else
                {
                    ExceptionLabel.Text = exception.Message;
                }
                File.AppendAllText("log.txt", new string('-', 80) +
                                              Environment.NewLine +
                                              DateTime.Now +
                                              Environment.NewLine +
                                              exception.Message +
                                              Environment.NewLine + exception.StackTrace);

                Cursor = DefaultCursor;
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                System.Windows.Forms.Application.DoEvents();
                startReplacing.Enabled = true;
            }
            /*
             * Still have no idea how to do that shit differently (to make the button unavailable for pressing even while
             * it's not enabled). After the button is enabled again apparently a buffer of some sort
             * is released and if someone press the button while not enabled, the button catch that event after
             * it gets enabled again. So apparently "DoEvents()", releases that "buffer" before the button is
             * enabled again.. ?!?... Again.. "probably"
             */
            System.Windows.Forms.Application.DoEvents();
            startReplacing.Enabled = true;
        }

        //The very essence of that application is to push some cells through that formula :D:D
        public static string Formula(string pzn)
        {
            try
            {
                var num = int.Parse(pzn);
                int a = (7*(num%10) + 6*((num/10)%10) + 5*((num/100)%10) + 4*((num/1000)%10) + 3*((num/10000)%10) +
                         2*((num/100000)%10));
                if ((a%11) == 10)
                    num = num*10;
                else
                    num = num*10 + (a%11);
                return num.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
        //"Convert"??? Hmmm... More like.. I don't know.., add a digit.
        public static void ConvertPZN(int rows, Range range)
        {
            var form = ActiveForm as Form1;
            form.ExceptionLabel.Text = PROCESSING;
            for (int count = 1; count <= rows; count++)
            {
                try
                {
                    string input = Convert.ToString((range.Cells[count, 1] as Range).Value);
                    string pzn = Formula(input);
                    (range.Cells[count, 1] as Range).Value = pzn ?? "";
                }
                catch (Exception)
                {
                    //throw up; //:D
                }
            }
        }

        //Yeah.. Right!?! Still have no idea how to do that properly.
        public static void AddBorders(int rows, int cols, Range tableRange)
        {
            bool isEmpty = true;
            for (int rCount = 1; rCount <= rows; ++rCount)
            {
                Range cell;
                for (int cCount = 1; cCount <= cols; ++cCount)
                {
                    cell = tableRange.Cells[rCount, cCount];
                    if (Convert.ToString(cell.Value) != null)
                        isEmpty = false;
                }
                if (!isEmpty)
                {
                    for (int cCount = 1; cCount <= cols; ++cCount)
                    {
                        cell = tableRange.Cells[rCount, cCount];
                        cell.BorderAround();
                    }
                }
            }
        }
    }
}
