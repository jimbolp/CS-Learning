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
using System.ComponentModel;

namespace ObjectToExcelTable
{
    class Program
    {
        //public static Dictionary<string, List<string> > LinkedObjHeaderAndContent { get; set; } = new Dictionary<string, List<string> >();
        //public static Dictionary<string, List<string> > LinkedListHeaderAndContent { get; set; } = new Dictionary<string, List<string> >();
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
            List<PackingListItem> lPli2 = new List<PackingListItem>();
            lPli2.Add(pli);
            lPli2.Add(pli2);
            lPli2.Add(pli3);
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
                items = lPli,
                items2 = lPli2
            };
            ReportFromObj rfo = new ReportFromObj(pl);
            rfo.ExportToExcel();
            /*
            GetPropertiesOneByOne(pl);
            Print();
            ExcelTable();
            Console.ReadLine();//*/
        }/*
        public static bool GetAttributes(IEnumerable<object> o)
        {
            foreach (var objs in o)
            {
                if (objs is DisplayNameAttribute)
                    return true;
            }
            return false;
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
                        foreach (PropertyInfo propInfo in propInfos)
                        {
                            if (propInfo.GetValue(enumPi) is String || !(typeof(IEnumerable).IsAssignableFrom(propInfo.PropertyType)))
                            {
                                if (GetAttributes(propInfo.GetCustomAttributes()))
                                {
                                    string AttrName = propInfo.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                                    ProcessSimpleTypeProperty(propInfo, enumPi, true, AttrName);
                                }
                            }
                        }
                        //GetPropertiesOneByOne(enumPi);
                    }
                else if (pi.CanRead)
                {
                    if (GetAttributes(pi.GetCustomAttributes()))
                    {
                        string AttrName = pi.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                        ProcessSimpleTypeProperty(pi, o, false, AttrName);
                    }
                    //ProcessSimpleTypeProperty(pi, o, false);
                }
            }            
        }
        private static void ProcessSimpleTypeProperty(PropertyInfo pi, object o, bool isCollectionProp, string propDispName)
        {
            if (isCollectionProp)
            {
                if (!LinkedListHeaderAndContent.ContainsKey(propDispName))
                {
                    if (string.IsNullOrEmpty(propDispName))
                        LinkedListHeaderAndContent[pi.Name] = new List<string>() { pi.GetValue(o, null).ToString() };
                    else
                        LinkedListHeaderAndContent[propDispName] = new List<string>() { pi.GetValue(o, null).ToString() };
                }
                else
                {
                    if (string.IsNullOrEmpty(propDispName))
                        LinkedListHeaderAndContent[pi.Name].Add(pi.GetValue(o, null).ToString());
                    else
                        LinkedListHeaderAndContent[propDispName].Add(pi.GetValue(o, null).ToString());
                }
            }
            else
            {
                if (!LinkedObjHeaderAndContent.ContainsKey(pi.Name))
                {
                    if (string.IsNullOrEmpty(propDispName))
                        LinkedObjHeaderAndContent[pi.Name] = new List<string>() { pi.GetValue(o, null).ToString() };
                    else
                        LinkedObjHeaderAndContent[propDispName] = new List<string>() { pi.GetValue(o, null).ToString() };
                }
                else
                {
                    if (string.IsNullOrEmpty(propDispName))
                        LinkedObjHeaderAndContent[pi.Name].Add(pi.GetValue(o, null).ToString());
                    else
                        LinkedObjHeaderAndContent[propDispName].Add(pi.GetValue(o, null).ToString());
                }
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
            }
            try
            {
                string str = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine(str);
                xlWorkbook.SaveAs(str + "\\test.xlsx");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                xlWorkbook.Close(false);
                xlApp.Quit();
                releaseObject(xlSheet);
                releaseObject(xlWorkbook);
                releaseObject(xlApp);
            }
        }
        private static void FormatTable(Worksheet xlWorksheet)
        {
            //Align and autofit the whole table
            Range xlRange = xlWorksheet.UsedRange;
            xlRange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
            xlRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            xlRange.Columns.AutoFit();

            //Table Range without the List properties
            int startRow = 1;
            int startCol = 1;
            int endRow = LinkedObjHeaderAndContent.Keys.Count;
            int endCol = 0;
            foreach (var key in LinkedObjHeaderAndContent.Keys)
                if (LinkedObjHeaderAndContent[key].Count > endCol)
                    endCol = LinkedObjHeaderAndContent[key].Count;
            Range startCell = xlWorksheet.Cells[startRow, startCol];
            Range endCell = xlWorksheet.Cells[endRow, startCol];
            Range titleRow = null;

            //Table Range only for the List properties
            int startListRow = endRow + 1;
            int endListCol = LinkedListHeaderAndContent.Keys.Count;
            Range startListHeader = xlWorksheet.Cells[startListRow, startCol];
            Range endListHeader = xlWorksheet.Cells[startListRow, endListCol];
            Range ListHeaderRange = null;//
                        
            
            try
            {
                ListHeaderRange = xlWorksheet.Range[startListHeader, endListHeader];
                titleRow = xlWorksheet.Range[startCell, endCell];
            }
            catch (Exception e)
            {
                throw e;
            }

            titleRow.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            titleRow.VerticalAlignment = XlVAlign.xlVAlignCenter;
            titleRow.Font.Bold = true;
            ListHeaderRange.Font.Bold = true;
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
            
        }//*/
    }
}
