using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Office.Interop.Excel;

namespace ExcelTest
{
    partial class Form1
    {
        public static string Formula(string pzn)
        {
            try
            {
                int currentDigit = Int32.Parse(pzn[pzn.Length - 1].ToString());
                var num = Int32.Parse(pzn);
                int a = (7 * ((num / 1) % 10) + 6 * ((num / 10) % 10) + 5 * ((num / 100) % 10) + 4 * ((num / 1000) % 10) + 3 * ((num / 10000) % 10) + 2 * ((num / 100000) % 10));
                if ((a % 11) == 10)
                    num = num * 10;
                else
                    num = num * 10 + (a % 11);
                return num.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ConvertPZN(int rows, Range range)
        {
            ExceptionLabel.Text = "Обработват се полетата....";
            for (int count = 1; count <= rows; count++)
            {
                try
                {
                    string input = (range.Cells[count, 1] as Range).Value.ToString();
                    string pzn = Formula(input);
                    (range.Cells[count, 1] as Range).Value = pzn ?? "";
                }
                catch (NullReferenceException up)
                {
                    //ExceptionLabel.Text += up.Message + Environment.NewLine;
                    //throw up; //haha... Not my idea... but I like it :D
                }
            }
        }

        public static void AddBorders(int rows, int cols, Range tableRange)
        {
            for (int rCount = 1; rCount <= rows; ++rCount)
            {
                for (int cCount = 1; cCount <= cols; ++cCount)
                {
                    Range cell = tableRange.Cells[rCount, cCount];
                    cell.BorderAround();
                }
            }
        }
    }
}
