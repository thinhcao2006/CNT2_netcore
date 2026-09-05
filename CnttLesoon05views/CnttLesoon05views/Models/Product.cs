namespace CnttLesoon05views.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsHot { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
