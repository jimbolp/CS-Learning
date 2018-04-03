using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebAppExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Numbers()
        {
            return View();
        }

        public ActionResult Files(string path = @"C:\")
        {
            path = Path.GetFullPath(path);

            var allfiles = new List<string>();
            allfiles.AddRange(Directory.GetFiles(path));
            allfiles.AddRange(Directory.GetDirectories(path));

            ViewBag.ParentFolder = path + @"\..\";

            return View(allfiles);
        }
    }
}