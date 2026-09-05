using Microsoft.AspNetCore.Mvc;

namespace CnttLesoon05views.ViewComponents
{
    // Slide 22 & 23: View Component độc lập quản lý menu danh mục
    public class CategoryMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = new List<string>
            {
                "Laptop & Máy tính",
                "Điện thoại thông minh",
                "Máy tính bảng (Tablet)",
                "Thiết bị đeo thông minh",
                "Lập trình ASP.NET Core MVC"
            };

            return await Task.FromResult(View(categories));
        }
    }
}
