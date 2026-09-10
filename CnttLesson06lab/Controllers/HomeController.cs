using System.Diagnostics;
using CnttLesson06lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson06lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected Book _book = new Book();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Trang chủ - load sách mới nhất từ View Action
        public IActionResult Index()
        {
            var books = _book.GetBookList();
            return View(books);
        }

        // Giới thiệu
        public IActionResult Privacy()
        {
            return View();
        }

        // Liên hệ
        public IActionResult Contact()
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
