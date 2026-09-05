using System.Diagnostics;
using CnttLesoon05views.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesoon05views.Controllers
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

        /*
         * Slide 21: Tạo action trả về PartialView phục vụ việc gọi Ajax / nhúng linh hoạt.
         * Trả về danh sách các sản phẩm HOT qua _ProductHotPartialView
         */
        public PartialViewResult GetProductHot()
        {
            List<Product> productHot = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop Dell XPS 15", Price = 45000000, Category = "Laptop", IsHot = true, Description = "Core i9 13900H, 32GB RAM, OLED 3.5K Touch" },
                new Product { Id = 2, Name = "iPhone 15 Pro Max", Price = 34000000, Category = "Điện thoại", IsHot = true, Description = "Titan Tự Nhiên 256GB, Chip A17 Pro" },
                new Product { Id = 3, Name = "Samsung Galaxy S24 Ultra", Price = 31000000, Category = "Điện thoại", IsHot = true, Description = "256GB, Bút S-Pen, AI Camera 200MP" },
                new Product { Id = 4, Name = "MacBook Air M3", Price = 28000000, Category = "Laptop", IsHot = true, Description = "13.6 inch, 8-Core CPU 10-Core GPU, 16GB Unified Memory" }
            };

            return PartialView("_ProductHotPartialView", productHot);
        }

        public IActionResult Razor()
        {
            return View();
        }

        public IActionResult About()
        {
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
