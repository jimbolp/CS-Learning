using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ObjectToExcelTable
{
    static class ObjFromXlFile
    {
        private enum ColumnNumber:int
        {
            StoreName = 1,
            PosCodeName = 2,
            PalletID = 3,
            ArticleID = 4,
            Producer = 5,
            ArticleName = 6,
            ParcelNo = 7,
            ExpiryDate = 8,
            Qty = 9
        }
        public static PosCodeItemsSql PosCodeFromFile(string path)
        {
            PosCodeItemsSql Items = new PosCodeItemsSql(true);
            FileInfo fi;
            //MemoryStream ms;

            ExcelPackage ep;
            //ExcelWorkbook xlWBook;
            ExcelWorksheet xlWsheet;
            try
            {
                fi = new FileInfo(path);
                ep = new ExcelPackage(fi);
                //xlWBook = ep.Workbook;

                xlWsheet = ep.Workbook.Worksheets[1];
            }
            catch (Exception)
            {
                throw;
            }
            PosCodeItemsSql pcItems;
            try
            {
                pcItems = TakeRange(xlWsheet);
            }
            catch(Exception)
            {
                throw;
            }
            return pcItems;
        }
        private static PosCodeItemsSql TakeRange(ExcelWorksheet xlWSheet)
        {
            string range = xlWSheet.Dimension.Address;
            ExcelRangeBase er = xlWSheet.Cells[range];
            int startRow = 4;
            int endRow = er.Rows;

            PosCodeItemsSql Doc = new PosCodeItemsSql(true);
            for (int i = startRow; i <= endRow; ++i)
            {
                int? palletID = null;
                int? articleID = null;
                int? qty = null;
                DateTime? expiryDate = null;
                int nullableInt = 0;
                if (int.TryParse((xlWSheet.Cells[i, (int)ColumnNumber.PalletID, i, (int)ColumnNumber.PalletID].Value).ToString(), out nullableInt))
                {
                    palletID = nullableInt;
                }
                if (int.TryParse((xlWSheet.Cells[i, (int)ColumnNumber.ArticleID, i, (int)ColumnNumber.ArticleID].Value).ToString(), out nullableInt))
                {
                    articleID = nullableInt;
                }                
                DateTime d;
                if (DateTime.TryParse((xlWSheet.Cells[i, (int)ColumnNumber.ExpiryDate, i, (int)ColumnNumber.ExpiryDate].Value).ToString(), out d))
                {
                    expiryDate = d;
                }
                if (int.TryParse((xlWSheet.Cells[i, (int)ColumnNumber.Qty, i, (int)ColumnNumber.Qty].Value).ToString(), out nullableInt))
                {
                    qty = nullableInt;
                }
                try
                {
                    Doc.items.Add(new PosCodeItemSql()
                    {
                        StoreName = (xlWSheet.Cells[i, (int)ColumnNumber.StoreName, i, (int)ColumnNumber.StoreName].Value).ToString(),
                        PosCodeName = (xlWSheet.Cells[i, (int)ColumnNumber.PosCodeName, i, (int)ColumnNumber.PosCodeName].Value).ToString(),
                        PalletID = palletID,
                        ArticleID = articleID,
                        Producer = (xlWSheet.Cells[i, (int)ColumnNumber.Producer, i, (int)ColumnNumber.Producer].Value).ToString(),
                        ArticleName = (xlWSheet.Cells[i, (int)ColumnNumber.ArticleName, i, (int)ColumnNumber.ArticleName].Value).ToString(),
                        ParcelNo = (xlWSheet.Cells[i, (int)ColumnNumber.ParcelNo, i, (int)ColumnNumber.ParcelNo].Value).ToString(),
                        ExpiryDate = expiryDate,
                        Qty = qty
                    });
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return Doc;
        }
    }
}
