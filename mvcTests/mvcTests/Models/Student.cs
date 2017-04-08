using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcTests.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [DisplayName("Name")]
        public string StudentName { get; set; }
        [DisplayName("")]
        public int Age { get; set; }
        public bool isNewlyEnrolled { get; set; }
        public string Password { get; set; }
    }
}