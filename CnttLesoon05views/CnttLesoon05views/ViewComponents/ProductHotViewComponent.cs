using CnttLesoon05views.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesoon05views.ViewComponents
{
    // Slide 22 & 23: Class C# kế thừa từ lớp ViewComponent
    // Tên lớp kết thúc bằng "ViewComponent"
    public class ProductHotViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int limit = 3)
        {
            // Giả lập lấy dữ liệu riêng biệt không phụ thuộc vào Controller
            var products = new List<Product>
            {
                new Product { Id = 101, Name = "MacBook Pro M3 Max", Price = 59990000, Category = "Laptop", IsHot = true, Description = "Chip M3 Max 14-core CPU, 30-core GPU, 36GB RAM, 1TB SSD" },
                new Product { Id = 102, Name = "iPhone 15 Pro Max 512GB", Price = 34990000, Category = "Điện thoại", IsHot = true, Description = "Khung titan siêu nhẹ, chip A17 Pro, camera 5x optical zoom" },
                new Product { Id = 103, Name = "Samsung Galaxy S24 Ultra", Price = 31990000, Category = "Điện thoại", IsHot = true, Description = "Galaxy AI bứt phá, bút S-Pen tích hợp, màn hình QHD+ 120Hz" },
                new Product { Id = 104, Name = "Dell XPS 16 Touch", Price = 48500000, Category = "Laptop", IsHot = true, Description = "Intel Core Ultra 9, OLED 4K Touch Screen, RTX 4070" },
                new Product { Id = 105, Name = "iPad Pro M4 13 inch", Price = 37990000, Category = "Tablet", IsHot = true, Description = "Màn hình Ultra Retina Tandem OLED, chip M4 siêu mỏng" }
            };

            var hotProducts = products.Where(p => p.IsHot).Take(limit).ToList();

            // Trả về view default nằm trong Views/Shared/Components/ProductHot/Default.cshtml
            return await Task.FromResult(View(hotProducts));
        }
    }
}
