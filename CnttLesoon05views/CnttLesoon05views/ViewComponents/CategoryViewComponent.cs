using CnttLesoon05views.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesoon05views.ViewComponents
{
    // Slide 24: Chuột phải vào ViewComponents -> Thêm class mới. 
    // Phần kết thúc của tên bắt buộc phải là "ViewComponent" (CategoryViewComponent.cs)
    public class CategoryViewComponent : ViewComponent
    {
        // Slide 25 & 27: Định nghĩa phương thức Invoke có thể nhận tham số (int? n)
        public IViewComponentResult Invoke(int? n)
        {
            List<Category> categories = new List<Category>()
            {
                new Category { CategoryId = 1, CategoryName = "Điện tử" },
                new Category { CategoryId = 2, CategoryName = "Điện lạnh" },
                new Category { CategoryId = 3, CategoryName = "Đồ gia dụng" },
                new Category { CategoryId = 4, CategoryName = "Tiện ích" }
            };

            // Slide 27: Lọc danh mục có CategoryId > n (nếu có tham số n truyền vào)
            if (n.HasValue)
            {
                var search = categories.Where(x => x.CategoryId > n.Value).ToList();
                return View(search);
            }

            return View(categories);
        }
    }
}
