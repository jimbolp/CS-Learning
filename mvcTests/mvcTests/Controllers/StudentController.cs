using System;
using System.Collections.Generic;
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
        // GET: Student
        public ActionResult Index()
        {            
            return View(StudentList);
        }
        private void resetLists()
        {
            StudentList = new List<Student>{
                            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
                            new Student() { StudentID = 4, StudentName = "Chris" , Age = 17 } ,
                            new Student() { StudentID = 4, StudentName = "Rob" , Age = 19 }
            };
            AllStudents = new Students(StudentList);
        }
        [ActionName("Export")]
        public ActionResult Export()
        {
            //Student student = StudentList.Where(s => s.StudentID == id).FirstOrDefault();
            //ReportFromObj r = new ReportFromObj(AllStudents);
            ReportFromObj r = null;
            try
            {
                //r = new ReportFromObj(StudentList);
                r = new ReportFromObj(AllStudents);
            }
            catch (ParameterNotValidException e)
            {
                return RedirectToAction("ExportError", e);
            }
            resetLists();
            r.ExportByXml();
            //r.ExportToExcel();
            return RedirectToAction("Index");
        }
        public ActionResult ExportError(Exception message)
        {
            return View(message);
        }
    }
}