using Microsoft.AspNetCore.Mvc;
using CnttLesson04Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CnttLesson04Lab.Controllers
{
    public class ProductController : Controller
    {
        // Danh sách Category tĩnh làm mock data
        private static readonly List<Category> CategoriesList = new List<Category>()
        {
            new Category { Id = 1, Name = "Quần Áo" },
            new Category { Id = 2, Name = "Túi xách" },
            new Category { Id = 3, Name = "Đồng hồ" },
            new Category { Id = 4, Name = "Tivi" },
            new Category { Id = 5, Name = "Tủ lạnh" },
            new Category { Id = 6, Name = "Máy bơm" },
            new Category { Id = 7, Name = "Quạt điện" },
            new Category { Id = 8, Name = "Lò sưởi" }
        };

        // Danh sách Product tĩnh để dùng chung cho cả Index và Details
        private static readonly List<Product> ProductsList = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Bộ đồ bơi cho trẻ em nam",
                CategoryId = 1,
                Price = 50000,
                SalePrice = 35000,
                Image = "/images/products/swim_boys.png",
                Description = "Bộ đồ bơi cho bé trai được thiết kế với chất liệu co giãn tốt, họa tiết ngộ nghĩnh đáng yêu giúp bé luôn thoải mái khi bơi lội dưới nước.",
                Status = 1,
                CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
            },
            new Product()
            {
                Id = 2,
                Name = "Bộ đồ bơi cho trẻ em nữ",
                CategoryId = 1,
                Price = 60000,
                SalePrice = 35000,
                Image = "/images/products/swim_girls.png",
                Description = "Đồ bơi bé gái thiết kế điệu đà, dễ thương với sắc hồng cánh sen, chất liệu chống thấm nhanh khô, an toàn tuyệt đối cho làn da bé.",
                Status = 1,
                CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
            },
            new Product()
            {
                Id = 3,
                Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
                CategoryId = 1,
                Price = 60000,
                SalePrice = 35000,
                Image = "/images/products/swim_girls.png",
                Description = "Mẫu swimsuit bé gái 3-5 tuổi màu sắc tươi sáng, thun cao cấp mềm mịn giúp các bé tự do hoạt động cả ngày dài tại bãi biển hay hồ bơi.",
                Status = 1,
                CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
            },
            new Product()
            {
                Id = 4,
                Name = "Bộ đồ bơi cho trẻ em thời trang",
                CategoryId = 1,
                Price = 80000,
                SalePrice = 35000,
                Image = "/images/products/swim_boys.png",
                Description = "Sản phẩm đồ bơi trẻ em phong cách thời trang năng động kết hợp bảo vệ da khỏi tia UV hiệu quả, chất vải bền bỉ không phai màu.",
                Status = 1,
                CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
            },
            new Product()
            {
                Id = 5,
                Name = "Túi thời trang mẫu mới 2021",
                CategoryId = 2,
                Price = 80000,
                SalePrice = 35000,
                Image = "/images/products/fashion_bag.png",
                Description = "Túi xách nữ thanh lịch đón đầu xu hướng thời trang 2021, chất da PU mềm mại kết hợp quai đeo xích mạ vàng sang trọng quý phái.",
                Status = 1,
                CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
            },
            new Product()
            {
                Id = 6,
                Name = "Túi thời trang da cá sấu",
                CategoryId = 2,
                Price = 80000,
                SalePrice = 35000,
                Image = "/images/products/fashion_bag.png",
                Description = "Dòng túi xách cao cấp dập vân da cá sấu nổi bật thích hợp cho các buổi tiệc tùng hay đi làm văn phòng, tôn lên vẻ thanh lịch của bạn.",
                Status = 1,
                CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
            }
        };

        // Đổi route mặc định của ProductController sang san-pham
        [Route("san-pham", Name = "product_index")]
        public IActionResult Index(int? cid)
        {
            var products = ProductsList;
            if (cid.HasValue)
            {
                products = products.Where(p => p.CategoryId == cid.Value).ToList();
            }

            ViewBag.Categories = CategoriesList;
            ViewBag.SelectedCategoryId = cid;
            
            return View(products);
        }

        // Định nghĩa route hiển thị chi tiết sản phẩm theo id
        [Route("chi-tiet-san-pham", Name = "product_details")]
        public IActionResult Details(int id)
        {
            var product = ProductsList.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
