using CnttLesoon03.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesoon03.Controllers
{
    [Route("/danh-sach-san-pham")]
    public class CnttProductController : Controller
    {
        // Mock data
        private readonly List<CnttProduct> _products = new()
        {
             new CnttProduct
    {
        CnttProductId = "CNTT001",
        CnttProductName = "Laptop Dell Inspiron 15",
        CnttYearRelease = 2024,
        CnttPrice = 18500000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT002",
        CnttProductName = "Laptop ASUS Vivobook 15",
        CnttYearRelease = 2024,
        CnttPrice = 15900000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT003",
        CnttProductName = "Laptop Lenovo IdeaPad 5",
        CnttYearRelease = 2023,
        CnttPrice = 17200000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT004",
        CnttProductName = "MacBook Air M2",
        CnttYearRelease = 2022,
        CnttPrice = 24500000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT005",
        CnttProductName = "iPhone 15",
        CnttYearRelease = 2023,
        CnttPrice = 18900000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT006",
        CnttProductName = "Samsung Galaxy S24",
        CnttYearRelease = 2024,
        CnttPrice = 20900000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT007",
        CnttProductName = "iPad Air M2",
        CnttYearRelease = 2024,
        CnttPrice = 16900000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT008",
        CnttProductName = "Dell UltraSharp Monitor 27",
        CnttYearRelease = 2023,
        CnttPrice = 8500000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT009",
        CnttProductName = "Logitech MX Master 3S",
        CnttYearRelease = 2022,
        CnttPrice = 2200000
    },
    new CnttProduct
    {
        CnttProductId = "CNTT010",
        CnttProductName = "Sony WH-1000XM5",
        CnttYearRelease = 2022,
        CnttPrice = 7490000
    }
        };
        public IActionResult Index()
        {
            return Json(_products);
        }
        // Collection => view
        [Route("all")]
        public IActionResult CnttGetAllProduct()
        {
            ViewData["Products"] = _products;
            return View();
        }
    }
}
