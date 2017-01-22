using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Runtime.InteropServices;


namespace CustomersCollectedOrder
{
    public partial class CustomersCollectedOrders : Form
    {
        public CustomersCollectedOrders()
        {
            InitializeComponent();
        }
        
        private void customerNoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isValid(customerNoTextBox.Text))
            {
                customerNoTextBox.Text = "";
                
            }
        }
        
        private void routeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isValid(routeTextBox.Text))
            {
                routeTextBox.Text = "";
            }
        }
        private void timeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isValid(timeTextBox.Text))
            {
                timeTextBox.Text = "";
            }
        }
        bool isValid(string input)
        {
            try
            {
                int.Parse(input);
            }
            catch
            {
                if (input != "" && input != null)
                    labelResult.Text = "Въведете число!";
                return false;
            }
            return true;
        }
        private string PharmacyName(Range range)
        {
            for(int i = 1; i < range.Rows.Count; ++i)
            {
                try
                {
                    string cell = Convert.ToString((range.Cells[i, 1] as Range).Value);
                    var customerNumber = Convert.ToInt32(cell.Trim());
                    //if(customerNumber != "" && customerNumber != null)
                    if (Convert.ToInt32(customerNoTextBox.Text) == customerNumber)
                    {
                        return Convert.ToString((range.Cells[i, 2] as Range).Value);
                    }
                }
                catch (Exception e)
                {
                    File.AppendAllText("log.txt",
                    new string('-', 80) +
                    Environment.NewLine +
                    DateTime.Now +
                    Environment.NewLine +
                    e.Message +
                    Environment.NewLine +
                    e.StackTrace);
                }
            }
            return "Няма такъв клиент във файла!";
        }
        private void buttonResult_Click(object sender, EventArgs e)
        {
            buttonResult.Enabled = false;
            clear.Enabled = false;
            labelResult.Text = "Обработва се...";
            var xlApp = new Application();
            try
            {
                Workbook xlWorkbook = xlApp.Workbooks.Open(Path.GetFullPath("sborni klienti.xlsx"), ReadOnly: false, Format: 5,
                    IgnoreReadOnlyRecommended: true,
                    Origin: XlPlatform.xlWindows, Delimiter: "\t", Editable: true, Notify: true, AddToMru: false,
                    Local: 1, CorruptLoad: 0);
                Worksheet xlWorksheet = xlWorkbook.ActiveSheet;
                Range xlRange = xlWorksheet.UsedRange;
                if (isSafeToClick())
                {
                    labelResult.Text = "Клиент номер: " + customerNoTextBox.Text + Environment.NewLine +
                        PharmacyName(xlRange) +
                        Environment.NewLine +
                        "Маршрут: " + routeTextBox.Text + Environment.NewLine +
                        "Час: " + timeTextBox.Text + Environment.NewLine +
                        "Време: " + calculateRouteTime();
                    File.AppendAllText("log.txt",
                        new string('-', 80) +
                        Environment.NewLine +
                        DateTime.Now +
                        Environment.NewLine +
                        "Клиент номер: " + customerNoTextBox.Text + " - " +  
                        PharmacyName(xlRange) +
                        Environment.NewLine +
                        "Маршрут: " + routeTextBox.Text + 
                        "Час: " + timeTextBox.Text + 
                        "Време: " + calculateRouteTime() +
                        Environment.NewLine);
                    System.Windows.Forms.Application.DoEvents();
                    buttonResult.Enabled = true;
                    clear.Enabled = true;

                }
                else
                {
                    labelResult.Text = "Празно поле!";
                    System.Windows.Forms.Application.DoEvents();
                    buttonResult.Enabled = true;
                    clear.Enabled = true;
                }
                xlWorkbook.Close(false);
                Marshal.FinalReleaseComObject(xlWorksheet);
                Marshal.FinalReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                if (isSafeToClick())
                {
                    labelResult.Text = "Клиент номер: " + customerNoTextBox.Text + Environment.NewLine +
                        //PharmacyName(xlRange) +
                        //Environment.NewLine +
                        "Маршрут: " + routeTextBox.Text + Environment.NewLine +
                        "Час: " + timeTextBox.Text + Environment.NewLine +
                        "Време: " + calculateRouteTime();
                    File.AppendAllText("log.txt",
                        new string('-', 80) +
                        Environment.NewLine +
                        DateTime.Now +
                        Environment.NewLine +
                        "Клиент номер: " + customerNoTextBox.Text + Environment.NewLine +
                        "Маршрут: " + routeTextBox.Text + Environment.NewLine +
                        "Час: " + timeTextBox.Text + Environment.NewLine +
                        "Време: " + calculateRouteTime() +
                        Environment.NewLine + 
                        ex.Message + 
                        Environment.NewLine + 
                        ex.StackTrace);
                    System.Windows.Forms.Application.DoEvents();
                    buttonResult.Enabled = true;
                    clear.Enabled = true;

                }
                else
                {
                    labelResult.Text = "Празно поле!";
                    System.Windows.Forms.Application.DoEvents();
                    buttonResult.Enabled = true;
                    clear.Enabled = true;
                }
                //xlWorkbook.Close(false);
                //Marshal.FinalReleaseComObject(xlWorksheet);
                //Marshal.FinalReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
            }
        }
        bool isSafeToClick()
        {
            if (routeTextBox.Text == "" || timeTextBox.Text == "")
                return false;
            else
                return true;
        }
        void clearTextBoxes()
        {
            customerNoTextBox.Text = "";
            routeTextBox.Text = "";
            timeTextBox.Text = "";
            labelResult.Text = "";
        }
        string calculateRouteTime()
        {
            int route = Convert.ToInt32(routeTextBox.Text);
            int time = Convert.ToInt32(timeTextBox.Text);
            var result = Convert.ToString(((((route % 10000) / 100) % 24) * 60) + (route % 100) + ((24 * 60) - (((time / 100) * 60) + (time % 100))));
            return result;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void CustomersCollectedOrders_Load(object sender, EventArgs e)
        {
            //loadExcelFile();
        }

        private void timeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonResult_Click(sender, e);
            }
        }
    }

}
