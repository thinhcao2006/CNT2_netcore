using System.ComponentModel.DataAnnotations;

namespace CnttLesson12.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống tên danh mục")]
        [StringLength(100, ErrorMessage = "Tên không quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        public int Status { get; set; } = 1;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<Product>? Products { get; set; }
    }
}
