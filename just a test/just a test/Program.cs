using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace just_a_test
{
    class Program
    {
        interface InterF
        {
            void shit();
            
        }

        class Inher : InterF
        {
            public void shit()
            {
                Console.WriteLine("first inher func...");
            }

            public void shit2()
            {
                Console.WriteLine("second inher func...");
            }
        }
        static void Main(string[] args)
        {
            Inher test = new Inher();
            test.shit();
            test.shit2();
            

            /* var application = new Application();
            var fileDialog = new OpenFileDialog();
            //fileDialog.ShowDialog();
            Workbook workbookCopyingFrom = application.Workbooks.Open("E:\\Documents\\GitHub\\CS-Learning\\Dixel Sensors\\Dixel Sensors\\bin\\Debug\\a.xls");
            
            Workbook workbookCopyingTo = application.Workbooks.Open("E:\\Documents\\GitHub\\CS-Learning\\Dixel Sensors\\Dixel Sensors\\bin\\Debug\\b.xls");
            

            var worksheetContainingRangeIWantToCopyAcross = workbookCopyingFrom.Sheets[1] as Worksheet;

            if (worksheetContainingRangeIWantToCopyAcross != null)
            {
                var worksheetIWantToCopyToInWorkbookTwo = workbookCopyingTo.Sheets[1] as Worksheet;

                if (worksheetIWantToCopyToInWorkbookTwo != null)
                {
                    var usedRangeInWorkbookCopyingTo = worksheetIWantToCopyToInWorkbookTwo.UsedRange;

                    worksheetContainingRangeIWantToCopyAcross.UsedRange.Copy(worksheetIWantToCopyToInWorkbookTwo.Rows);

                    worksheetIWantToCopyToInWorkbookTwo.Rows.Clear();

                    worksheetIWantToCopyToInWorkbookTwo.Rows.Insert(
                        CopyOrigin: worksheetContainingRangeIWantToCopyAcross.UsedRange);
                }
            }

            workbookCopyingTo.Save();
            workbookCopyingTo.Close();

            application.Quit();

            Marshal.ReleaseComObject(application);//*/
        }
    }
}
