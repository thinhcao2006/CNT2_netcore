namespace CnttLesson02Theory.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int YearRelease { get; set; }
        public double Price { get; set; }
    }
}
