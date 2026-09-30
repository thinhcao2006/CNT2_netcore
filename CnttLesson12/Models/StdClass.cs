using System.ComponentModel.DataAnnotations;

namespace CnttLesson12.Models
{
    public class StdClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp không được để trống")]
        [StringLength(100, ErrorMessage = "Tên lớp không quá 100 ký tự")]
        [Display(Name = "Tên lớp")]
        public string ClassName { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Student>? Students { get; set; }
    }
}
