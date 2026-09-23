using System.ComponentModel.DataAnnotations;

namespace CnttLesson09Annotation.Models
{
    public class TvcStudent
    {
        public int TvcStudentId { get; set; }

        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(20, ErrorMessage = "Mã sinh viên tối đa 20 ký tự")]
        [Display(Name = "Mã sinh viên")]
        public string TvcStudentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(100, ErrorMessage = "Họ tên tối đa 100 ký tự")]
        [Display(Name = "Họ và tên")]
        public string TvcFullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string TvcEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string TvcPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngành học không được để trống")]
        [StringLength(100, ErrorMessage = "Ngành học tối đa 100 ký tự")]
        [Display(Name = "Ngành học")]
        public string TvcMajor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime TvcBirthday { get; set; }

        [Range(1, 5, ErrorMessage = "Năm học phải từ 1 đến 5")]
        [Display(Name = "Năm học")]
        public int TvcYear { get; set; } = 1;
    }
}
