using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CnttLesson12.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sinh viên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên không quá 100 ký tự")]
        [Display(Name = "Họ tên")]
        public string StudentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [StringLength(100, ErrorMessage = "Email không quá 100 ký tự")]
        [Display(Name = "Email")]
        public string StudentEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(50, ErrorMessage = "Số điện thoại không quá 50 ký tự")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string StudentPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(150, ErrorMessage = "Địa chỉ không quá 150 ký tự")]
        [Display(Name = "Địa chỉ")]
        public string StudentAddress { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "Ảnh đại diện")]
        public string StudentAvatar { get; set; } = "/images/avatars/default.png";

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime StudentBirthday { get; set; }

        // Foreign Key
        [Required(ErrorMessage = "Vui lòng chọn lớp học")]
        [Display(Name = "Lớp")]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public StdClass? StdClass { get; set; }

        // Navigation property
        public ICollection<Mark>? Marks { get; set; }
    }
}
