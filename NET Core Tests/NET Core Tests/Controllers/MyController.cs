
using Microsoft.AspNetCore.Mvc;

namespace NETCoreTests.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Albums()
        {
            ViewData["Test"] = "test viewdata";
            Models.TestModel testModel = new Models.TestModel();
            testModel.ModelGuid = 124;
            testModel.ModelName = "Testing the abstraction of the view!";
            return View(testModel);
        }
    }
}
