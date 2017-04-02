using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application = Microsoft.Office.Interop.Excel.Application;
using Microsoft.Office.Interop.Excel;

namespace ObjectToExcelTable
{
    class Program
    {
        public static Dictionary<string, List<string> > LinkedHeaderAndContent { get; set; } = new Dictionary<string, List<string> >();
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
           
            List<PackingListItem> lPli = new List<PackingListItem>();
            lPli.Add(pli);
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
            Console.ReadLine();
        }
        public static void GetPropertiesOneByOne(object o)
        {            
            Type t = o.GetType();
            PropertyInfo[] p = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //За всяко пропърти правим проверка дали си нямаме работа с колекция
            foreach (PropertyInfo pi in p)
            {
                //Ако пропъртито е от тип IEnumerable, извъртаме колекцията и подаваме всеки един обект от нея отново на нашия метод (изключваме String от сметките)
                if (typeof(IEnumerable).IsAssignableFrom(pi.PropertyType) && !(pi.GetValue(o) is String))
                    foreach (var enumPi in (IEnumerable)pi.GetValue(o))
                        GetPropertiesOneByOne(enumPi);
                else
                    ProcessSimpleTypeProperty(pi, o);
            }            
        }

        private static void ProcessSimpleTypeProperty(PropertyInfo pi, object o)
        {
            if (!LinkedHeaderAndContent.ContainsKey(pi.Name))
            {
                LinkedHeaderAndContent[pi.Name] = new List<string>() { pi.GetValue(o, null).ToString() };
            }
            else
                LinkedHeaderAndContent[pi.Name].Add(pi.GetValue(o, null).ToString());
            
            //Console.WriteLine(" -> " + pi.GetValue(o, null));
        }
        private static void Print()
        {
            foreach (var key in LinkedHeaderAndContent.Keys)
            {
                Console.WriteLine(key);
                foreach (var value in LinkedHeaderAndContent[key])
                    Console.WriteLine(" -> " + value);
            }
        }
        private static void ExcelTable()
        {
            var xlApp = new Application();
            Workbook xlWorkbook = new Workbook();
            Range xlSheet = xlWorkbook.Sheets[0];
            
        }
    }
}
