using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application = Microsoft.Office.Interop.Excel.Application;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ObjectToExcelTable
{
    class Program
    {
        public static Dictionary<string, List<string> > LinkedObjHeaderAndContent { get; set; } = new Dictionary<string, List<string> >();
        public static Dictionary<string, List<string> > LinkedListHeaderAndContent { get; set; } = new Dictionary<string, List<string>>();
        public static void Main(string[] args)
        {
            PackingListItem pli = new PackingListItem()
            {
                ArticleID = 6263,
                ArticleName = "Аналгин",
                ParcelNo = "32545",
                ExpiryDate = DateTime.Now,
                Qty = 1000,
                PalletID = 4325,
                PalletBarcode = 4324,
                PosCodeID = 12,
                PosCodeName = "posCodeName",
                StoreID = 22,
                StoreName = "София"                
            };
            PackingListItem pli2 = new PackingListItem()
            {
                ArticleID = 63644,
                ArticleName = "Зопиклон",
                ParcelNo = "3221855",
                ExpiryDate = DateTime.Now,
                Qty = 50000,
                PalletID = 1254444,
                PalletBarcode = 235656456,
                PosCodeID = 50,
                PosCodeName = "Каса",
                StoreID = 23,
                StoreName = "Бургас"
            };
            PackingListItem pli3 = new PackingListItem()
            {
                ArticleID = 12546,
                ArticleName = "Парацетмол",
                ParcelNo = "133532",
                ExpiryDate = DateTime.Now,
                Qty = 3546,
                PalletID = 123,
                PalletBarcode = 4321,
                PosCodeID = 50,
                PosCodeName = "Каса",
                StoreID = 25,
                StoreName = "Пловдив"
            };

            List<PackingListItem> lPli = new List<PackingListItem>();
            lPli.Add(pli);
            lPli.Add(pli2);
            lPli.Add(pli3);
            PackingList pl = new PackingList()
            {
                AppID = 1,
                AppName = "TestApp",
                CustomerID = 2012101,
                CustomerName = "Test Pharmacy",
                DeliveryAddress = "Test str.",
                DocNo = 201,
                DocName = "Test Doc",
                DocDate = DateTime.Now,
                items = lPli
            };
            
            GetPropertiesOneByOne(pl);
            Print();
            ExcelTable();
            //Console.ReadLine();
        }
        public static void GetPropertiesOneByOne(object o)
        {            
            Type t = o.GetType();
            PropertyInfo[] p = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //За всяко пропърти правим проверка дали си нямаме работа с колекция
            foreach (PropertyInfo pi in p)
            {
                //Ако пропъртито е от тип IEnumerable, извъртаме колекцията и подаваме всеки един обект от нея отново на нашия метод (изключваме String от сметките)
                if (typeof(IEnumerable).IsAssignableFrom(pi.PropertyType) && !(pi.GetValue(o) is String) && pi.CanRead)
                    foreach (var enumPi in (IEnumerable)pi.GetValue(o))
                    {
                        Type propertyType = enumPi.GetType();
                        PropertyInfo[] propInfos = propertyType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                        foreach(PropertyInfo propInfo in propInfos)
                        {
                            if (propInfo.GetValue(enumPi) is String || !(typeof(IEnumerable).IsAssignableFrom(propInfo.PropertyType)))
                            {
                                ProcessSimpleTypeProperty(propInfo, enumPi, true);
                            }
                        }
                        //GetPropertiesOneByOne(enumPi);
                    }
                else if (pi.CanRead)
                    ProcessSimpleTypeProperty(pi, o, false);
            }            
        }
        private static void ProcessSimpleTypeProperty(PropertyInfo pi, object o, bool isCollectionProp)
        {
            if (isCollectionProp)
            {
                if (!LinkedListHeaderAndContent.ContainsKey(pi.Name))
                {
                    LinkedListHeaderAndContent[pi.Name] = new List<string>() { pi.GetValue(o, null).ToString() };
                }
                else
                    LinkedListHeaderAndContent[pi.Name].Add(pi.GetValue(o, null).ToString());
            }
            else
            {
                if (!LinkedObjHeaderAndContent.ContainsKey(pi.Name))
                {
                    LinkedObjHeaderAndContent[pi.Name] = new List<string>() { pi.GetValue(o, null).ToString() };
                }
                else
                    LinkedObjHeaderAndContent[pi.Name].Add(pi.GetValue(o, null).ToString());
            }                        
        }
        private static void Print()
        {
            foreach (var key in LinkedObjHeaderAndContent.Keys)
            {
                Console.WriteLine(key);
                foreach (var value in LinkedObjHeaderAndContent[key])
                    Console.WriteLine(" -> " + value);
            }
            Console.WriteLine(new string('=', 10));
            foreach (var key in LinkedListHeaderAndContent.Keys)
            {
                Console.WriteLine(key);
                foreach (var value in LinkedListHeaderAndContent[key])
                    Console.WriteLine(" -> " + value);
            }
        }
        private static void ExcelTable()
        {
            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet xlSheet = xlWorkbook.Sheets[1];
            
            int r = 1;
            int c = 1;
            int listRow = 0;
            foreach(string key in LinkedObjHeaderAndContent.Keys)
            {
                try
                {                    
                    (xlSheet.Cells[r, c++] as Range).Value = separateWords(key);
                    foreach (string value in LinkedObjHeaderAndContent[key])
                        (xlSheet.Cells[r, c++] as Range).Value = value;
                    c = 1;
                    listRow = ++r;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    xlWorkbook.Close(false);
                    xlApp.Quit();
                    releaseObject(xlSheet);
                    releaseObject(xlWorkbook);
                    releaseObject(xlApp);
                    return;
                }
            }
            c = 1;
            r = listRow;
            foreach(var key in LinkedListHeaderAndContent.Keys)
            {
                try
                {
                    (xlSheet.Cells[r++, c] as Range).Value = separateWords(key);
                    foreach (string value in LinkedListHeaderAndContent[key])
                        (xlSheet.Cells[r++, c] as Range).Value = value;
                    c++;
                    r = listRow;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    xlWorkbook.Close(false);
                    xlApp.Quit();
                    releaseObject(xlSheet);
                    releaseObject(xlWorkbook);
                    releaseObject(xlApp);
                    return;
                }
            }
            try
            {
                FormatTable(xlSheet);
            }
            catch (Exception)
            {
                //..
            }//*/
            xlWorkbook.SaveAs("C:\\Users\\yavor.georgiev\\Documents\\test.xlsx");
            xlWorkbook.Close(false);
            xlApp.Quit();
            releaseObject(xlSheet);
            releaseObject(xlWorkbook);
            releaseObject(xlApp);
        }
        private static void FormatTable(Worksheet xlWorksheet)
        {
            Range xlRange = xlWorksheet.UsedRange;
            int startRow = 1;
            int startCol = 1;

            int endRow = LinkedObjHeaderAndContent.Keys.Count;
            int endCol = 0;

            foreach (var key in LinkedObjHeaderAndContent.Keys)
                if (LinkedObjHeaderAndContent[key].Count > endCol)
                    endCol = LinkedObjHeaderAndContent[key].Count;
            
            xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
            xlRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            xlRange.Columns.AutoFit();
            Range startCell = xlWorksheet.Cells[startRow, startCol];
            Range endCell = xlWorksheet.Cells[endRow, startCol];
            Range titleRow = null;
            try
            {
                titleRow = xlWorksheet.Range[startCell, endCell];
            }
            catch (Exception e)
            {
                throw e;
            }
            titleRow.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            titleRow.VerticalAlignment = XlVAlign.xlVAlignCenter;
            titleRow.Font.Bold = true;
            foreach (Range c in xlRange.Cells)
            {
                c.BorderAround(XlLineStyle.xlContinuous,
                                        XlBorderWeight.xlThin,
                                        XlColorIndex.xlColorIndexAutomatic,
                                        XlColorIndex.xlColorIndexAutomatic);
            }
        }
        private static string separateWords(string str)
        {
            str = str.Trim();
            for(int i = 0; i < str.Length; ++i)
            {
                if (i != 0 && i < str.Length - 1
                    && (str[i + 1].ToString() == (str[i + 1]).ToString().ToUpper())
                    && str[i].ToString() != str[i].ToString().ToUpper())
                {
                    str = str.Insert(++i, " ");
                }
            }
            return str;
        }
        private static void releaseObject(object obj)
        {
                try
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
                catch (Exception ex)
                {
                    obj = null;
                    Console.Write("Exception Occured while releasing object " + ex.ToString());
                }
                finally
                {
                    GC.Collect();
                }
            
        }
    }
}
