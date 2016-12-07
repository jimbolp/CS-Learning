using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Dixel_Sensors
{
    public partial class Form1 : Form
    {
        const double COLD_MIN = 2.5;
        const double COLD_MAX = 7.5;
        const double TEMP_MIN = 16.0;
        const double TEMP_MAX = 24.0;
        const double HUMID_MIN = 35.0;
        const double HUMID_MAX = 55.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void startWorking_Click(object sender, EventArgs e)
        {
            doStuff();
            if (!startWorking.Enabled)
            {
                System.Windows.Forms.Application.DoEvents();
                startWorking.Enabled = true;
            }
        }
        /// <summary>
        /// The chart for the Humidity sensors has to be on a montly basis
        /// </summary>
        /// <param name="xlWorksheet"></param>
        private void createChartHumid(Worksheet xlWorksheet)
        {
            resultLabel.Text = "Обработва се графика за -> " + xlWorksheet.Name;
            ChartObjects xlChartObjects = xlWorksheet.ChartObjects();
            const double heigth = 521.0134; //18.23cm * 28.58
            const double width = 867.9746; //30.37cm * 28.58
            int startPositionLeft = 10;
            int startPositionTop = 300;

            //Range used for the current chart
            Range xlChartRange = xlWorksheet.UsedRange;
            ChartObject xlChartObject = xlChartObjects.Add(startPositionTop, startPositionLeft, width, heigth);
            xlChartObject.Chart.ChartType = XlChartType.xlLine;
            xlChartObject.Chart.HasTitle = true;
            Chart xlChartPage = xlChartObject.Chart;
            xlChartPage.ChartTitle.Text = xlWorksheet.Name;
            xlChartPage.SetSourceData(xlChartRange);
            xlChartPage.ChartType = XlChartType.xlLine;
            xlChartPage.Legend.Delete();
        }
        /// <summary>
        /// The temperature's chart has to be on a weekly basis
        /// </summary>
        /// <param name="xlWorksheet"></param>
        private void createChartTemps(Worksheet xlWorksheet)
        {
            ChartObjects xlChartObjects = xlWorksheet.ChartObjects();
            const double heigth = 521.0134; //18.23cm * 28.58
            const double width = 867.9746; //30.37cm * 28.58
            int startPositionLeft = 10;
            int startPositionTop = 300;

            //Range used for the current chart
            Range xlChartRange = xlWorksheet.UsedRange;
            int tableRows = xlChartRange.Rows.Count;
            int count = 2;
            string topRange = "A" + count;
            string bottomRange = "B" + count;
            bool firstDateOfRange = true;
            int tableCount = 1;
            for (int i = 1; i <= tableRows; ++i)
            {
                string strDate = Convert.ToString((xlChartRange.Cells[i, 1] as Range).Value);
                if (!string.IsNullOrEmpty(strDate))
                {
                    strDate = strDate.Trim().Split(' ').ToArray()[0].Trim();
                    DateTime cellDate;
                    if (DateTime.TryParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out cellDate))
                    {
                        if (cellDate.DayOfWeek == DayOfWeek.Monday)
                        {
                            if (firstDateOfRange)
                            {
                                bottomRange = "B" + i;
                                //firstDateOfRange = false;
                            }
                            else
                            {
                                resultLabel.Text = "Обработва се таблица - " + tableCount++;
                                Range currentChartRange = xlWorksheet.Range[topRange, bottomRange];
                                startPositionLeft += 600;
                                ChartObject xlChartObject = xlChartObjects.Add(startPositionTop, startPositionLeft, width, heigth);
                                xlChartObject.Chart.ChartType = XlChartType.xlLine;
                                xlChartObject.Chart.HasTitle = true;
                                Chart xlChartPage = xlChartObject.Chart;
                                xlChartPage.ChartTitle.Text = xlWorksheet.Name;
                                xlChartPage.SetSourceData(currentChartRange);
                                xlChartPage.ChartType = XlChartType.xlLine;
                                xlChartPage.Legend.Delete();
                                topRange = "A" + i;
                                bottomRange = "B" + i;
                                firstDateOfRange = true;
                            }
                        }
                        else
                        {
                            bottomRange = "B" + i;
                            firstDateOfRange = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Loading the Excel file and returning a Workbook as a result
        /// </summary>
        /// <param name="xlApp"></param>
        /// <param name="filePath"></param>
        /// <returns name="xlWorkbook"></returns>
        
        /// <summary>
        /// Cold sensors check
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private double changeColdTemps(double temp)
        {
            if (temp < COLD_MIN || temp > COLD_MAX)
            {
                var rand = new Random(Environment.TickCount);
                if (temp < COLD_MIN)
                {
                    var r = (double) rand.Next(1, 8)/10;
                    temp = temp + (COLD_MIN - temp) + r;
                }
                else
                {
                    var r = (double) rand.Next(1, 8)/10;
                    temp = temp - (temp - COLD_MAX) - r;
                }
                return temp;
            }
            return temp;
        }

        private double changeTemps(double temp)
        {
            if (temp < TEMP_MIN || temp > TEMP_MAX)
            {
                var rand = new Random(Environment.TickCount);
                if (temp < TEMP_MIN)
                {
                    var r = (double) rand.Next(1, 8)/10;
                    temp = temp + (TEMP_MIN - temp) + r;
                }
                else
                {
                    var r = (double) rand.Next(1, 8)/10;
                    temp = temp - (temp - TEMP_MAX) - r;
                }
                return temp;
            }
            return temp;
        }

        private double changeHumidity(double temp)
        {
            if (temp < HUMID_MIN || temp > HUMID_MAX)
            {
                var rand = new Random(Environment.TickCount);
                if (temp < HUMID_MIN)
                {
                    var r = (double) rand.Next(1, 8)/11;
                    temp = temp + (HUMID_MIN - temp) + r;
                }
                else
                {
                    var r = (double) rand.Next(1, 8)/10;
                    temp = temp - (temp - HUMID_MAX) - r;
                }
                return temp;
            }
            return temp;
        }

        private void loadTemps(Range xlRange, int rows)
        {
            List<double> temps = new List<double>();
            for (int i = 2; i < 6; ++i)
            {
                var cellValue = Convert.ToString((xlRange.Cells[i, 2] as Range).Value);
                if (cellValue == null || cellValue == " ")
                    continue;
                temps.Add(double.Parse(cellValue));
            }
            int switchSensors = temps.Sum(t => (int) t)/4;

            for (int i = 2; i < rows; ++i)
            {
                var cellValue = Convert.ToString((xlRange.Cells[i, 2] as Range).Value);
                if (cellValue == null || cellValue == " ")
                    continue;
                double temp;
                if (double.TryParse(cellValue, out temp))
                {
                    (xlRange.Cells[i, 2] as Range).Value = switchSensors < 15
                        ? changeColdTemps(temp)
                        : (switchSensors < 30 ? changeTemps(temp) : changeHumidity(temp));
                    resultLabel.Text = "... " + i + " от " + rows + " полета са обработени.";
                }
            }
        }

        private int TempsOrHumid(Range xlRange)
        {
            List<double> temps = new List<double>();
            for (int i = 2; i < 10; ++i)
            {
                var cellValue = Convert.ToString((xlRange.Cells[i, 2] as Range).Value);
                if (cellValue == null || cellValue == " ")
                    continue;
                double cell;
                if (double.TryParse(cellValue, out cell))
                {
                    temps.Add(cell);
                }
            }

            int switchSensors = temps.Sum(t => (int) t)/8; //First 8 values(temperatures) from the table
            if (switchSensors < 30)
                return 1;
            return 2;
        }

        private void doStuff()
        {
            
            if (filePathTextBox.Text.Trim() == "")
            {
                resultLabel.Text = "Преди да стартирате, заредете файла за обработка.";
                return;
            }
            if (Path.GetExtension(filePathTextBox.Text) != ".xls" && Path.GetExtension(filePathTextBox.Text) != ".xlsx")
            {
                resultLabel.Text = "Заредете валиден Excel файл. (Поддържаните разширения са: \".xls\" и \".xlsx\")";
                return;
            }
            startWorking.Enabled = false;
            Cursor = Cursors.WaitCursor;
            resultLabel.Text = "Файлът се отваря....";
            var xlApp = new Application();
            string fileName = filePathTextBox.Text;
            filePathTextBox.Text = "";
            var Sensors = new CustomXlBook(xlApp);
            try
            {
                Sensors.loadExcelFile(xlApp, fileName);
                resultLabel.Text = "Файлът е отворен успешно...";
                int sheetCount = 1;
                foreach (Worksheet sheet in Sensors.XlWorkbook.Worksheets)
                {
                    sheetNameLabel.Text = "Страница " + sheetCount++ + " от "
                                          + Sensors.XlWorkbook.Worksheets.Count + " (" + sheet.Name + "):";

                    Range range = sheet.UsedRange;
                    int rowsRange = range.Rows.Count;

                    //Start changing temps.................
                    //loadTemps(range, rowsRange);
                    switch (TempsOrHumid(range))
                    {
                        case 1:
                            createChartTemps(sheet);
                            break;
                        case 2:
                            createChartHumid(sheet);
                            break;
                    }
                }
                sheetNameLabel.Text = "";
                int count = 1;
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                                  + "\\savedCopy" + count + ".xls";
                while (File.Exists(filePath))
                {
                    count++;
                    filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                               + "\\savedCopy" + count + ".xls";
                }
                Sensors.XlWorkbook.SaveAs(filePath, AccessMode: XlSaveAsAccessMode.xlNoChange,
                    FileFormat: XlFileFormat.xlWorkbookNormal);
                if (Sensors.XlWorkbook.Saved)
                    resultLabel.Text = "Файлът е запазен:" + Environment.NewLine + filePath;
                else
                {
                    resultLabel.Text = "Файлът не може да бъде запазен!" +
                                       Environment.NewLine +
                                       "Проверете дали файла не се използва от друго приложение.";
                } //*/

                Sensors.XlWorkbook.Close(false);
                xlApp.Quit();
                Cursor = DefaultCursor;
                Marshal.ReleaseComObject(xlApp);
            }
                //catch 2...
            catch (COMException ce)
            {
                resultLabel.Text = ce.Message;
                File.AppendAllText("log.txt", new string('-', 80) +
                                              Environment.NewLine +
                                              DateTime.Now +
                                              Environment.NewLine +
                                              ce.Message +
                                              Environment.NewLine + ce.StackTrace);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                Cursor = DefaultCursor;

                System.Windows.Forms.Application.DoEvents();
                startWorking.Enabled = true;
            }
                //catch 3...
            catch (FileNotFoundException exception)
            {
                resultLabel.Text = "Файлът не беше намерен" +
                                   Environment.NewLine +
                                   exception.Message;

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                Cursor = DefaultCursor;
                System.Windows.Forms.Application.DoEvents();
                startWorking.Enabled = true;
            }
                //catch that shit already.. 
            catch (Exception exception)
            {
                if (exception.Message.Contains("We can't save"))
                    resultLabel.Text = "Файлът не може да бъде запаметен, защото се използва от друго приложение." +
                                       Environment.NewLine +
                                       "Моля затворете файла и опитайте отново";
                else
                {
                    resultLabel.Text = exception.Message;
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
                startWorking.Enabled = true;
            }
        }

        private class CustomXlBook
        {
            private Application _xlApp;
            private Workbook _xlWorkbook;

            public CustomXlBook(Application xlApp)
            {
                _xlApp = xlApp;
            }
            public void loadExcelFile(Application xlApp, string filePath)
            {
                try
                {
                    _xlWorkbook = xlApp.Workbooks.Open(filePath, ReadOnly: false, Format: 5,
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
                    //catch me if you can... 
                    throw new COMException("Невалиден файл!");
                }
            }

            public Workbook XlWorkbook => _xlWorkbook;
        }
        private void filePathTextBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void filePathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                filePathTextBox.Text = files[0];
            }
        }
    }
}