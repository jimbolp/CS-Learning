using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ConvertPZN
{
    public partial class Form1 : Form
    {
        const string FILE_NOT_FOUND = "Файлът не беше намерен. Проверете дали пътя е верен или файла не е изтрит.";
        const string FILE_NOT_SAVED = "Файлът не беше запаметен.";
        const string FILE_SAVED = "Файлът е променен успешно";
        const string BLANK_TEXT_BOX = "(Хвани и постави Excel файла тук)";
        const string PROCESSING = "Обработват се полетата....";
        
        public Form1()
        {
            InitializeComponent();
        }

        public void startReplacing_Click(object sender, EventArgs e)
        {
            OpenFileAndDoStuff();
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
                filePathTextBox.Text = files[0];
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Marshal.AreComObjectsAvailableForCleanup())
                Marshal.CleanupUnusedObjectsInCurrentContext();
        }

        private void killExcelButton_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Excel");
            if (MessageBox.Show("Сигурни ли сте, че искате да затворите всички Excel процеси?" +
                Environment.NewLine +
                "Ако имате отворени документи, промените няма да бъдат запазени!",
                "Опасна операция!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var p in processes)
                    p.Kill();
            }
        }
        private void filePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if(filePathTextBox.Text.Trim() == "")
                filePathTextBox.Text = filePathTextBox.Text.Trim();
            if (filePathTextBox.Text != BLANK_TEXT_BOX)
                filePathTextBox.ForeColor = Color.Black;
            else
                filePathTextBox.ForeColor = Color.LightGray;

            if (filePathTextBox.Text.Contains("pass:"))
            {
                filePathTextBox.PasswordChar = '*';
                killExcelButton.Enabled = filePathTextBox.Text == "pass:adm1n1strat0r";
            }
            else
            {
                filePathTextBox.PasswordChar = '\0';
                killExcelButton.Enabled = false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            filePathTextBox.Text = (args.Length > 1 && (Path.GetExtension(args[1]) == ".xlsx" ||
                Path.GetExtension(args[1]) == ".xls")) ? args[1] : BLANK_TEXT_BOX;
            Shown += Form1_Shown;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (filePathTextBox.Text != "" && filePathTextBox.Text != BLANK_TEXT_BOX)
                OpenFileAndDoStuff();
        }
    }
}
