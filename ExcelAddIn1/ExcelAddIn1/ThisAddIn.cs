using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            List<Account> bankAccounts = new List<Account>
            {
                new Account
                {
                    ID = 345,
                    Balance = 541.27
                },
                new Account
                {
                    ID = 123,
                    Balance = -127.44
                }
            };
            DisplayInExcel(bankAccounts, (account, cell) =>
            // This multiline lambda expression sets custom processing rules  
            // for the bankAccounts.
            {
                cell.Value = account.ID;
                cell.Offset[0, 1].Value = account.Balance;
                if (account.Balance < 0)
                {
                    cell.Interior.Color = 255;
                    cell.Offset[0, 1].Interior.Color = 255;
                }
            });
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
        }

        void DisplayInExcel(IEnumerable<Account> accounts, Action<Account, Excel.Range> DisplayFunc)
        {
            var excelApp = Application;
            excelApp.Workbooks.Add();
            excelApp.Visible = true;
            excelApp.Range["A1"].Value = "ID";
            excelApp.Range["B1"].Value = "Balance";
            excelApp.Range["A2"].Select();
            foreach (var a in accounts)
            {
                DisplayFunc(a, excelApp.ActiveCell);
                excelApp.ActiveCell.Offset[1, 0].Select();
            }
            // Copy the results to the Clipboard.
            excelApp.Range["A1:B3"].Copy();
            excelApp.Columns[1].AutoFit();
            excelApp.Columns[2].AutoFit();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
