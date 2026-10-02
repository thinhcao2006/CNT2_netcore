using Microsoft.AspNetCore.Mvc;

namespace CnttLesson13Layout.Controllers
{
    public class CnttProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string keyword)
        {
            ViewData["keyword"] = keyword;
            return View();
        }

        public IActionResult Hots()
        {
            return View();
        }
    }
}
