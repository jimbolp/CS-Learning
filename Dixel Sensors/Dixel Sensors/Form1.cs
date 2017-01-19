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
using Microsoft.Win32;
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

        static readonly string[] TEMPS_FOR_CHARTS =
        {
            "002 TwhDF-XJP60D", "044 TwhMF-XJP60D", "071 TwhUF-XJP60D",
            "074 TcdUF-XJP60D", "095 TcdSpediciaNew-XJP60D"
        };

        static readonly string[] HUMID_FOR_CHARTS =
        {
            "006 HwhDF-XJP60D",
            "017 Hcwh-XJP60D", "046 HwhMF-XJP60D", "075 HwhUFrP-XJP60D", "077 HwhUF-XJP60D"
        };
        
        public string SavedFilePath { get; set; }
        public List<Chart> ListOfCharts { get; set; } = new List<Chart>();
        public PrintPreviewDialog PrintPreview { get; set; } = new PrintPreviewDialog();
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

        private void CreateChart(ChartObject xlChartObject, Range xlChartRange, string worksheetName)
        {
            xlChartObject.Chart.ChartType = XlChartType.xlLine;
            xlChartObject.Chart.HasTitle = true;
            Chart xlChartPage = xlChartObject.Chart;
            xlChartPage.ChartTitle.Text = worksheetName;
            xlChartPage.ChartType = XlChartType.xlLine;
            xlChartPage.SetSourceData(xlChartRange);
            /*Axis a = (xlChartPage.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue,
                XlAxisGroup.xlPrimary) as Microsoft.Office.Interop.Excel.Axis);
            a.MinimumScale = 16.5;//*/

            //xlChartPage.ApplyChartTemplate(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\For Tests\\ChartTemplate.crtx");
            xlChartPage.Legend.Delete();
            //ListOfCharts.Add(xlChartPage);
            //xlApp.Visible = true;
            if(printCheckBox.Checked)
                xlChartPage.PrintOut();
            //xlApp.Visible = false;//*/
        }

        /// <summary>
        /// The chart for the Humidity sensors has to be on a montly basis
        /// </summary>
        /// <param name="xlWorksheet"></param>
        private void createChartHumid(Worksheet xlWorksheet)
        {
            resultLabel.Text = "Обработва се графика за -> " + xlWorksheet.Name;
            
            const double heigth = 521.0134; //18.23cm * 28.58
            const double width = 867.9746; //30.37cm * 28.58
            int startPositionLeft = 100;
            int startPositionTop = 100;

            //Range used for the current chart
            Range xlChartRange = xlWorksheet.UsedRange;
            ChartObjects xlChartObjects = xlWorksheet.ChartObjects();
            ChartObject xlChartObject = xlChartObjects.Add(startPositionLeft, startPositionTop, width, heigth);
            CreateChart(xlChartObject, xlChartRange, xlWorksheet.Name);

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
            int startPositionLeft = 100;
            int startPositionTop = 100;

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
                                startPositionTop += 600;
                                ChartObject xlChartObject = xlChartObjects.Add(startPositionLeft, startPositionTop, width, heigth);
                                CreateChart(xlChartObject, currentChartRange, xlWorksheet.Name);
                                topRange = "A" + i;
                                bottomRange = "B" + i;
                                firstDateOfRange = true;
                                System.Windows.Forms.Application.DoEvents();
                            }
                        }
                        else
                        {
                            bottomRange = "B" + i;
                            firstDateOfRange = false;
                            if (i == tableRows)
                            {
                                resultLabel.Text = "Обработва се таблица - " + tableCount++;
                                Range currentChartRange = xlWorksheet.Range[topRange, bottomRange];
                                startPositionTop += 600;
                                ChartObject xlChartObject = xlChartObjects.Add(startPositionLeft, startPositionTop, width, heigth);
                                CreateChart(xlChartObject, currentChartRange, xlWorksheet.Name);
                                System.Windows.Forms.Application.DoEvents();
                            }
                        }
                    }
                }
            }
        }
        
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
        /// <summary>
        /// Storage temperatures check
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Humidity check
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
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

        private void loadTemps(Worksheet sheet)
        {
            Range range = sheet.UsedRange;
            int rowsRange = range.Rows.Count;
            List<double> temps = new List<double>();
            for (int i = 2; i < 10; ++i)
            {
                var cellValue = Convert.ToString((range.Cells[i, 2] as Range).Value);
                if (cellValue == null || cellValue == " ")
                    continue;
                double temp;
                if(double.TryParse(cellValue, out temp))
                    temps.Add(temp);
            }
            int switchSensors = temps.Sum(t => (int) t)/8;

            for (int i = 2; i < rowsRange; ++i)
            {
                var cellValue = Convert.ToString((range.Cells[i, 2] as Range).Value);
                if (cellValue == null || cellValue == " ")
                    continue;
                double temp;
                if (double.TryParse(cellValue, out temp))
                {
                    (range.Cells[i, 2] as Range).Value = switchSensors < 15
                        ? changeColdTemps(temp)
                        : (switchSensors < 30 ? changeTemps(temp) : changeHumidity(temp));

                    resultLabel.Text = "... " + i + " от " + rowsRange + " полета са обработени.";
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        }

        /*private int TempsOrHumid(Range xlRange)
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
        }//*/

        private void SaveExceptionToFile(Exception e)
        {
            File.AppendAllText("log.txt", new string('-', 80) +
                                              Environment.NewLine +
                                              DateTime.Now +
                                              Environment.NewLine +
                                              e.Message +
                                              Environment.NewLine + e.StackTrace);
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
            Application xlApp = new Application();
            startWorking.Enabled = false;
            Cursor = Cursors.WaitCursor;
            resultLabel.Text = "Файлът се отваря....";
            
            string fileName = filePathTextBox.Text;
            filePathTextBox.Text = "";
            
            try
            {
                Workbook xlWorkbook = loadExcelFile(xlApp, fileName);
                resultLabel.Text = "Файлът е отворен успешно...";
                int sheetCount = 1;
                int sheetsNumber = xlWorkbook.Worksheets.Count;
                foreach (Worksheet sheet in xlWorkbook.Worksheets)
                {
                    resultLabel.Text = "";
                    sheetNameLabel.Text = "Страница " + sheetCount++ + " от "
                                          + sheetsNumber + " (" + sheet.Name + "):";

                    //Changing temps.................
                    if(tempsCheckBox.Checked)
                        loadTemps(sheet);
                    if (graphicsCheckBox.Checked)
                    {
                        if (TEMPS_FOR_CHARTS.Contains(sheet.Name))
                            createChartTemps(sheet);
                        else if (HUMID_FOR_CHARTS.Contains(sheet.Name))
                            createChartHumid(sheet);
                    }

                }//*/
                //tests(Sensors);
                
                sheetNameLabel.Text = "";

                /*try
                {
                    xlApp.Dialogs[XlBuiltInDialog.xlDialogPrint].Show(ListOfCharts[0]);

                }
                catch(COMException ce)
                {
                    SaveExceptionToFile(ce);
                }//*/
                
                if (SaveAndClose(xlWorkbook))
                    resultLabel.Text = "Файлът е запазен:" + Environment.NewLine + SavedFilePath;
                //*/

                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
                Cursor = DefaultCursor;
                System.Windows.Forms.Application.DoEvents();
                startWorking.Enabled = true;
            }
                //catch 3...
            catch (FileNotFoundException exception)
            {
                resultLabel.Text = "Файлът не беше намерен";
                SaveExceptionToFile(exception);

                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
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
                SaveExceptionToFile(exception);

                xlApp.Quit();
                Marshal.FinalReleaseComObject(xlApp);
                Cursor = DefaultCursor;
                System.Windows.Forms.Application.DoEvents();
                startWorking.Enabled = true;
            }
        }

        public void SetResultLabel(string str)
        {
            resultLabel.Text = str;
        }

        /// <summary>
        /// Loading the Excel file
        /// </summary>
        /// <param name="xlApp"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Workbook loadExcelFile(Application xlApp, string filePath)
        {
            try
            {
                Workbook XlWorkbook = xlApp.Workbooks.Open(filePath, ReadOnly: false, Format: 5,
                IgnoreReadOnlyRecommended: true,
                Origin: XlPlatform.xlWindows, Delimiter: "\t", Editable: true, Notify: true, AddToMru: false,
                Local: 1, CorruptLoad: 0);
                return XlWorkbook;
            }
            //catch 1...
            catch (COMException exception)
            {
                SaveExceptionToFile(exception);
                //catch me if you can... 
                throw exception;
            }
            
        }

        public bool SaveAndClose(Workbook xlWorkbook)
        {
            string[] nameWithExt = xlWorkbook.Name.Split('.').Select(x => x.Trim()).ToArray();
            string nameWithoutExt = (nameWithExt.Length == 1)? nameWithExt[0] : "";

            for (int i = 0; i < nameWithExt.Length-1; ++i)
            {
                nameWithoutExt += nameWithExt[i];
            }

            int count = 1;
            try
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx; *.xlsm",
                    Title = "Save As",
                    DefaultExt = "xls"
                };
                var initialPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (saveFileDialog.InitialDirectory == "")
                    saveFileDialog.InitialDirectory = initialPath;

                if (File.Exists(saveFileDialog.InitialDirectory + "\\" + nameWithoutExt + ".xls"))
                {
                    while (File.Exists(saveFileDialog.InitialDirectory + "\\" + nameWithoutExt + "(" + count + ").xls"))
                    {
                        count++;
                    }
                    nameWithoutExt = nameWithoutExt + "(" + count + ")";
                }
                
                saveFileDialog.FileName = nameWithoutExt;
                saveFileDialog.AddExtension = true;
                DialogResult temp = saveFileDialog.ShowDialog();
                if (temp == DialogResult.OK)
                {
                    SavedFilePath = saveFileDialog.FileName;
                    while (File.Exists(SavedFilePath))
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            SavedFilePath = saveFileDialog.FileName;
                        else
                            break;
                        /*count++;
                        SavedFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Saved Excel Files"
                                    + "\\savedCopy" + count + ".xls";//*/
                    }
                }
                else
                {
                    resultLabel.Text = "Файлът не беше запаметен.";
                    return false;
                }
                xlWorkbook.SaveAs(SavedFilePath, AccessMode: XlSaveAsAccessMode.xlNoChange,
                    FileFormat: XlFileFormat.xlWorkbookNormal);
                //SavedFilePath = filePath;

                xlWorkbook.Close(false);
                
                return true;
            }
                //catch 2...
            catch (COMException ce)
            {
                resultLabel.Text = ce.Message +
                                   Environment.NewLine +
                                   ce.StackTrace;
                SaveExceptionToFile(ce);
                xlWorkbook.Close(false);
                
                return false;
            }
        }

        /*private class CustomXlBook
        {
            private Application _xlApp;
            //private Workbook _xlWorkbook;
            private List<DateTime> _distinctDates;
            public string SavedFilePath { get; set; }
            //public List<DateTime> distinctDates => _distinctDates;
            public List<Workbook> XlWorkbooks = new List<Workbook>();
            public Application xlApp => _xlApp;

            public List<DateTime> GetListOfDistinctDates(Worksheet xlWorksheet)
            {
                _distinctDates = new List<DateTime>();
                Range tableRange = xlWorksheet.UsedRange;
                int rowsCount = tableRange.Rows.Count;
                for (int i = 1; i < rowsCount; ++i)
                {
                    string strDate = Convert.ToString((tableRange.Cells[i, 1] as Range).Value);
                    if (!string.IsNullOrEmpty(strDate))
                    {
                        strDate = strDate.Trim().Split(' ').ToArray()[0].Trim();
                        DateTime tempDate;
                        if (DateTime.TryParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out tempDate) && !_distinctDates.Contains(tempDate))
                        {
                            _distinctDates.Add(tempDate);
                        }
                    }
                }
                return _distinctDates;
            }

            public CustomXlBook(Application xlApp)
            {
                _xlApp = xlApp;
            }
        }//*/

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

        private void combineFiles_Click(object sender, EventArgs e)
        {
            var folderPath = new FolderBrowserDialog {ShowNewFolderButton = false};
            var dialogResult = folderPath.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                loadAllExcelFiles(folderPath.SelectedPath);
            }
            //xlApp.Quit();
            //Marshal.ReleaseComObject(xlApp);
        }

        private Range openExcelFile(string fullFilePath, Application xlApp)
        {
            Workbook wbToCopyFrom = xlApp.Workbooks.Open(fullFilePath, ReadOnly: false, Format: 5,
                IgnoreReadOnlyRecommended: true,
                Origin: XlPlatform.xlWindows, Delimiter: "\t", Editable: true, Notify: true, AddToMru: false,
                Local: 1, CorruptLoad: 0);
            Worksheet wsToCopy = wbToCopyFrom.ActiveSheet;
            var rangeToCopy = wsToCopy.UsedRange;
            rangeToCopy.Copy();
            wbToCopyFrom.Close();
            Marshal.ReleaseComObject(wbToCopyFrom);
            return rangeToCopy;
        }
        private void loadAllExcelFiles(string folderPath)
        {
            
            string[] allFilesInFolder = Directory.GetFiles(folderPath);
            IEnumerable<string> filesNames = from file in
                                    allFilesInFolder
                                    where Path.GetExtension(file) == ".xls"
                                    select file;
            Application xlApp = new Application();
            Workbook wb = xlApp.Workbooks.Add();
            Worksheet ws = wb.ActiveSheet;
            //Range newRange = ws.UsedRange;
            foreach (var fileName in filesNames)
            {
                //newRange.PasteSpecial(XlInsertShiftDirection.xlShiftDown, openExcelFile(folderPath, fileName));
                openExcelFile(folderPath + "\\" + fileName, xlApp);
                ws.Paste();
            }
            SaveAndClose(wb);
            Marshal.FinalReleaseComObject(wb);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Marshal.AreComObjectsAvailableForCleanup())
            {
                Marshal.CleanupUnusedObjectsInCurrentContext();
            }
        }

        private void graphicsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (graphicsCheckBox.Checked)
            {
                printCheckBox.Enabled = true;
            }
            else
            {
                printCheckBox.Checked = false;
                printCheckBox.Enabled = false;
            }
        }
        //------------
        /*private void tests(CustomXlBook Sensor)
        {
            //CustomXlBook TestCopy = new CustomXlBook(xlApp);
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.ShowDialog();
            //if (!string.IsNullOrEmpty(fbd.SelectedPath))
            //{
                var newWorkbook = Sensor.xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                var newWorkSheet = (Worksheet)newWorkbook.ActiveSheet;
                Range newRange = newWorkSheet.UsedRange;
                var oldWorkbook = Sensor.XlWorkbooks[0];
                var oldWorkSheet = (Worksheet)oldWorkbook.Worksheets[1];
                Range oldRange = oldWorkSheet.UsedRange;
                //oldRange.Insert(XlInsertShiftDirection.xlShiftDown, newRange);
                oldRange.Copy();
                newWorkSheet.Paste();
                //newWorkSheet.Rows.Insert(XlInsertShiftDirection.xlShiftDown, oldWorkSheet);
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\For Tests\\NewExcelTests.xls";
                newWorkbook.SaveAs(filePath, XlFileFormat.xlWorkbookNormal);
            //}
        }//*/
    }
}