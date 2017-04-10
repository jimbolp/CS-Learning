using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcTests.Models;
using ObjectToExcelTable;

namespace mvcTests.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> StudentList = new List<Student>{
                            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
                            new Student() { StudentID = 4, StudentName = "Chris" , Age = 17 } ,
                            new Student() { StudentID = 4, StudentName = "Rob" , Age = 19 }
            };
        public Students AllStudents = new Students(StudentList);
        public PackingList pl = new PackingList();
        public PackingListItem pli = new PackingListItem();
        public PackingListItem pli2 = new PackingListItem();
        public PackingListItem pli3 = new PackingListItem();
        // GET: Student
        public ActionResult Index()
        {            
            return View(StudentList);
        }
        private void initializePackingList()
        {
            pli = new PackingListItem()
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
            pli2 = new PackingListItem()
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
            pli3 = new PackingListItem()
            {
                ArticleID = 12546,
                ArticleName = "Парацетамол",
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
            pl = new PackingList()
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
        }
        [ActionName("Export")]
        public ActionResult Export()
        {
            //Student student = StudentList.Where(s => s.StudentID == id).FirstOrDefault();
            //ReportFromObj r = new ReportFromObj(AllStudents);
            ReportFromObj r = null;
            initializePackingList();
            try
            {
                
                //r = new ReportFromObj(StudentList);
                r = new ReportFromObj(pl);
            }
            catch (ParameterNotValidException e)
            {
                return RedirectToAction("ExportError", e);
            }
            MemoryStream ms = new MemoryStream();
            ms.SetLength(0);
            ms = r.ExportByXml();
            Response.Clear();
            Response.Buffer = false;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
            ms.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
            
            ms.SetLength(0);
            //r.ExportToExcel();
            return RedirectToAction("Index","Home");
        }
        public ActionResult ExportError(Exception message)
        {
            return View(message);
        }
    }
}