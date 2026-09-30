using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CnttLesson12.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống tên sản phẩm")]
        [StringLength(100, ErrorMessage = "Tên không quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        public string? Image { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int Status { get; set; } = 1;

        // Foreign Key
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
