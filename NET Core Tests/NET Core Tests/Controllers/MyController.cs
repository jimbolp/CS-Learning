
using Microsoft.AspNetCore.Mvc;

namespace NET_Core_Tests.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Albums()
        {
            ViewData["Test"] = "test viewdata";
            return View();
        }
    }
}
