using CnttLesson02Theory.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson02Theory.Controllers
{
    public class CnttProductController : Controller
    {
        // Action mặc định khi Controller được tạo ra
        // Trả về View có tên trùng với tên Action trong thư mục /Views/CnttProduct/Index.cshtml
        // Có truyền dữ liệu qua ViewData, ViewBag, và TempData (Slide 12-13)
        public IActionResult Inde  x()
        {
            ViewData["messageVD"] = "Dữ liệu lưu trong ViewData";
            ViewBag.messageVB = "Dữ liệu lưu trong ViewBag";
            TempData["messageTD"] = "Dữ liệu lưu trong TempData";
            return View();
        }

        // Định nghĩa Action mới
        // Trả về view có tên là Products trong thư mục /Views/CnttProduct/Products.cshtml
        public IActionResult GetAllProducts()
        {
            return View("Products");
        }

        // Đưa dữ liệu dạng Object ra View (Slide 14)
        public IActionResult GetProducts()
        {
            Product p = new Product
            {
                ProductId = 1,
                ProductName = "Trek 820 - 2016",
                YearRelease = 2016,
                Price = 379.99
            };
            
            ViewBag.product = p;
            ViewData["productVD"] = p;

            return View();
        }
    }
}
