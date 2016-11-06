using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelTest
{
    public partial class Form1 : Form
    {
        const string FILE_NOT_FOUND = "Файлът не беше намерен. Проверете дали пътя е верен или файла не е изтрит.";
        const string FILE_NOT_SAVED = "Файлът не беше запаметен.";
        const string FILE_SAVED = "Файлът е променен успешно";
        const string BLANK_TEXT_BOX = "(Хвани и поостави Excel файла тук)";
        public Form1()
        {
            InitializeComponent();
        }

        public void startReplacing_Click(object sender, EventArgs e)
        {
            
            Cursor = Cursors.WaitCursor;
            ExceptionLabel.Text = "Файлът се отваря....";
            var xlApp = new Application();
            //xlApp = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                string rememberFilePath = filePathTextBox.Text;
                var xlWorkBook = xlApp.Workbooks.Open(filePathTextBox.Text, ReadOnly: false, Format: 5,
                    IgnoreReadOnlyRecommended: true,
                    Origin: XlPlatform.xlWindows, Delimiter: "\t", Editable: true, Notify: true, AddToMru: true,
                    Local: 1, CorruptLoad: 0);
                
                Worksheet xlWorkSheet = (Worksheet) xlWorkBook.Worksheets.Item[1];
                Range range = xlWorkSheet.UsedRange;
                int rowsRange = range.Rows.Count;
                int colsRange = range.Columns.Count;

                Thread newThread = new Thread(() => ConvertPZN(rowsRange, range));
                newThread.Start();

                ExceptionLabel.Text = "Малко форматиране и сме готови....";
                AddBorders(rowsRange, colsRange, range);
                range.Columns.AutoFit();
                
                xlWorkBook.Save();
                if (xlWorkBook.Saved)
                    ExceptionLabel.Text = FILE_SAVED;
                else
                {
                    ExceptionLabel.Text = FILE_NOT_SAVED;
                }
                xlWorkBook.Close();
                xlApp.Quit();
                newThread.Join();
                
                Cursor = DefaultCursor;
                Marshal.ReleaseComObject(xlApp);
                
            }
            catch (FileNotFoundException exception)
            {
                ExceptionLabel.Text = FILE_NOT_FOUND +
                    Environment.NewLine + exception.Message;
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception exception)
            {
                ExceptionLabel.Text = exception.Message;
                Cursor = DefaultCursor;
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
        }

        
        private void ExceptionLabel_Click(object sender, EventArgs e)
        {
            //ExceptionLabel.Text = $"Не натискай тук... Отгоре има бутони.";
        }

        private void filePathTextBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void filePathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                //ExceptionLabel.Text = files[0];
                filePathTextBox.Text = files[0];
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void killExcelButton_Click(object sender, EventArgs e)
        {
            
            Process[] process = Process.GetProcessesByName("Excel");
            
            foreach (var p in process)
            {                
                    p.Kill();
            }
        }

        private void filePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (filePathTextBox.Text != BLANK_TEXT_BOX)
                filePathTextBox.ForeColor = Color.Black;
            else
            {
                filePathTextBox.ForeColor = Color.LightGray;
            }
            if (filePathTextBox.Text.Contains("pass:"))
            {
                filePathTextBox.PasswordChar = '*';
                if (filePathTextBox.Text == "pass:adm1n1strat0r")
                {
                    killExcelButton.Enabled = true;
                    killExcelButton.Cursor = DefaultCursor;
                }
            }
            else
            {
                killExcelButton.Enabled = false;
                killExcelButton.Cursor = Cursors.No;
            }

        }

        private void filePathTextBox_Enter(object sender, EventArgs e)
        {
            if (filePathTextBox.Text == BLANK_TEXT_BOX)
            {
                filePathTextBox.Text = "";
            }
        }

        private void filePathTextBox_Leave(object sender, EventArgs e)
        {
            if (filePathTextBox.Text == "")
                filePathTextBox.Text = BLANK_TEXT_BOX;
        }

        private void loadExcelFile_Click(object sender, EventArgs e)
        {
            openExcelFile.Filter = "Excel Workbook|*.xlsx; *.xlsm|Excel 97-2003 Workbook|*.xls";
            openExcelFile.Title = "Open Excel Workbook";
            if (openExcelFile.ShowDialog() == DialogResult.OK)
                filePathTextBox.Text = openExcelFile.FileName;
        }
    }
}
