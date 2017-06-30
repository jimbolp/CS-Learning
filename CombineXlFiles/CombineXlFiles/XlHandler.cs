using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using App = Microsoft.Office.Interop.Excel.Application;
using Wb = Microsoft.Office.Interop.Excel.Workbook;

namespace CombineXlFiles
{
    public class XlHandler
    {
        App xlApp = new App();
        Workbooks Wbs;

        Wb xlNewWbook;
        
        public XlHandler()
        {
            Wbs = xlApp.Workbooks;
            xlNewWbook = Wbs.Add();
            xlNewWbook.Activate();
        }
        
        public void CopyFileToNewWB(string file)
        {
            Wb wbToCopyFrom;            
            try
            {
                wbToCopyFrom = Wbs.Open(file);
            }
            catch (Exception)
            {
                throw new Exception("Unable to open the file!");
            }
            foreach(Worksheet sh in wbToCopyFrom.Sheets)
            {
                if (NewBookContainsSheet(sh.Name))
                {
                    Worksheet wsToCopyTo = GetSheetFromNewWb(sh.Name);
                    WorksheetMerge(sh, wsToCopyTo);
                }
                else
                {
                    Worksheet newSheet =  xlNewWbook.Sheets.Add(After: xlNewWbook.Worksheets[xlNewWbook.Sheets.Count], Count: 1);
                    newSheet.Name = sh.Name;
                    WorksheetMerge(sh, newSheet);
                }
            }
            wbToCopyFrom.Close(false);
            Wbs.Close();
            //ReleaseObject(wbToCopyFrom);
        }
        public void SaveNewFile()
        {
            MainForm.SaveFileName();
            string sfd = MainForm.fileNameToSave;
            if (sfd != null)
            {
                try
                {
                    foreach(Worksheet wsh in xlNewWbook.Sheets)
                    {
                        wsh.UsedRange.RemoveDuplicates(Type.Missing, Header: XlYesNoGuess.xlYes);
                    }
                    xlNewWbook.SaveAs(sfd);
                }
                catch (Exception)
                {
                    MessageBox.Show("File not saved due to an error!!");
                    Dispose();
                }
            }        
            Dispose();
        }

        private void Dispose()
        {
            xlNewWbook.Close(false);
            Wbs.Close();
            xlApp.Quit();
            ReleaseObject(xlNewWbook);
            ReleaseObject(Wbs);
            ReleaseObject(xlApp);
        }

        private bool NewBookContainsSheet(string sheetName)
        {
            foreach(Worksheet wsh in xlNewWbook.Sheets)
            {
                if(wsh.Name == sheetName)
                {
                    return true;
                }
            }
            return false;
        }
        private Worksheet GetSheetFromNewWb(string sheetName)
        {
            foreach(Worksheet ws in xlNewWbook.Sheets)
            {
                if (ws.Name == sheetName)
                    return ws;
            }
            return null;
        }
        //
        private void WorksheetMerge(Worksheet original, Worksheet destination)
        {
            Range rngOriginal = original.UsedRange;
            rngOriginal.Copy(Type.Missing);

            Range rngDestinationLastCell = destination.UsedRange.Offset[destination.UsedRange.Rows.Count, 0];

            rngDestinationLastCell.PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
            ReleaseObject(rngOriginal);
            ReleaseObject(original);
            MainForm.ClearClipboard();
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (COMException cEx)
            {
                obj = null;
                MessageBox.Show("Com Exception Occured while releasing object " + cEx.ToString());
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }
    }
}
