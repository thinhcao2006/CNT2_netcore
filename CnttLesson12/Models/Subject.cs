using System.ComponentModel.DataAnnotations;

namespace CnttLesson12.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên môn học không được để trống")]
        [StringLength(100, ErrorMessage = "Tên môn học không quá 100 ký tự")]
        [Display(Name = "Tên môn học")]
        public string SubjectName { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Mark>? Marks { get; set; }
    }
}
