using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
//using Application = Microsoft.Office.Interop.Excel.Application;

namespace just_a_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[6][];
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }
            List<int> maxSum = new List<int>();
            List<int> currentSum = new List<int>();
            for (int i = 0; (i + 2) < 6; ++i)
            {
                for (int j = 0; (j + 2) < 6; ++j)
                {
                    currentSum = new List<int>();
                    currentSum.Add(arr[i][j]);
                    currentSum.Add(arr[i][j + 1]);
                    currentSum.Add(arr[i][j + 2]);
                    currentSum.Add(arr[i + 1][j + 1]);
                    currentSum.Add(arr[i + 2][j]);
                    currentSum.Add(arr[i + 2][j + 1]);
                    currentSum.Add(arr[i + 2][j + 2]);
                    if (SumListEl(currentSum) > SumListEl(maxSum) || maxSum.Count == 0)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            foreach (var l in maxSum)
            {
                Console.Write(l + ", ");
            }
            Console.WriteLine();
            Console.WriteLine(SumListEl(maxSum));
            
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
        static int SumListEl(List<int> list)
        {
            int sum = 0;
            foreach (var el in list)
            {
                sum += el;
            }
            return sum;
        }
    }
}
