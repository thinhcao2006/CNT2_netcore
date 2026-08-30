using Microsoft.AspNetCore.Mvc;

namespace CnttLesson04Lab.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
