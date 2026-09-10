using System.ComponentModel.DataAnnotations;

namespace CnttLesson06lab.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập tên lớp")]
        [Display(Name = "Lớp")]
        public string ClassName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        [Display(Name = "Giới tính")]
        public string Gender { get; set; } = string.Empty;

        [Range(0.0, 4.0, ErrorMessage = "GPA phải từ 0.0 đến 4.0")]
        [Display(Name = "GPA")]
        public double GPA { get; set; }

        // Computed property for display
        public int Age => DateTime.Today.Year - DateOfBirth.Year -
                          (DateTime.Today < DateOfBirth.AddYears(DateTime.Today.Year - DateOfBirth.Year) ? 1 : 0);

        public string GpaRank => GPA switch
        {
            >= 3.6 => "Xuất sắc",
            >= 3.2 => "Giỏi",
            >= 2.5 => "Khá",
            >= 2.0 => "Trung bình",
            _ => "Yếu"
        };
    }
}
