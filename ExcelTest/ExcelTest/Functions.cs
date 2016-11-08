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
        private void OpenFileAndDoStuff()
        {
            if (counter != 0)
                return;
            if (filePathTextBox.Text == BLANK_TEXT_BOX || filePathTextBox.Text.Trim() == "")
            {
                ExceptionLabel.Text = "Преди да стартирате, заредете файла за обработка.";
                return;
            }

            Cursor = Cursors.WaitCursor;
            ExceptionLabel.Text = "Файлът се отваря....";
            var xlApp = new Application();
            try
            {
                string rememberFilePath = filePathTextBox.Text;
                Workbook xlWorkBook = xlApp.Workbooks.Open(filePathTextBox.Text, ReadOnly: false, Format: 5,
                    IgnoreReadOnlyRecommended: true,
                    Origin: XlPlatform.xlWindows, Delimiter: "\t", Editable: true, Notify: true, AddToMru: false,
                    Local: 1, CorruptLoad: 0);

                Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.Item[1];
                Range range = xlWorkSheet.UsedRange;
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
            catch (COMException ce)
            {
                ExceptionLabel.Text = FILE_NOT_FOUND +
                                      Environment.NewLine +
                                      ce.Message;
                Cursor = DefaultCursor;
            }
            catch (FileNotFoundException exception)
            {
                ExceptionLabel.Text = FILE_NOT_FOUND +
                    Environment.NewLine +
                    exception.Message;
                xlApp.Quit();
                Cursor = DefaultCursor;
                Marshal.ReleaseComObject(xlApp);
            }
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
                xlApp.Workbooks.Close();
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                counter++;
            }
        }
        public static string Formula(string pzn)
        {
            try
            {
                var num = int.Parse(pzn);
                int a = (7*((num/1)%10) + 6*((num/10)%10) + 5*((num/100)%10) + 4*((num/1000)%10) + 3*((num/10000)%10) +
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
                catch (Exception up)
                {
                    //throw up; //:D
                }
            }
        }

        public static void AddBorders(int rows, int cols, Range tableRange)
        {
            for (int rCount = 2; rCount <= rows; ++rCount)
            {
                for (int cCount = 1; cCount <= cols; ++cCount)
                {
                    Range cell = tableRange.Cells[rCount, cCount];
                    //if(Convert.ToString(cell.Value) != "" && Convert.ToString(cell.Value) != null)
                    cell.BorderAround();
                }
            }
        }
    }
}
