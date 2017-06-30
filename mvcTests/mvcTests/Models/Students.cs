using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace mvcTests.Models
{
    public class Students
    {
        [DisplayName("")]
        public string ClassName { get; set; }
        [DisplayName("Number of Students")]
        public int StudentNumber { get; set; }

        public List<Student> StudentList { get; set; }
        public Students(List<Student> list)
        {
            ClassName = "Student List";
            StudentList = list;
            StudentNumber = StudentList.Count;
        }
    }
}