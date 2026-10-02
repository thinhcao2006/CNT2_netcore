using Microsoft.AspNetCore.Mvc;

namespace CnttLesson13Layout.Areas.CnttAdmins.Controllers
{
    [Area("CnttAdmins")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
