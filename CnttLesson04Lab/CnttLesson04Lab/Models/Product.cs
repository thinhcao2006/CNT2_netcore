using System;

namespace CnttLesson04Lab.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; } // 1 is "Còn hàng", 0 is "Hết hàng"
        public DateTime CreatedAt { get; set; }
    }
}
