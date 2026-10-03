using System.Diagnostics;
using CnttLesson14.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson14.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Trang giới thiệu thông tin dự án.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Trang thông tin liên hệ.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
