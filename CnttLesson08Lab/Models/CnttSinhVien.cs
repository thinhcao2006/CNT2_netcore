using System.ComponentModel.DataAnnotations;

namespace CnttLesson08Lab.Models
{
    /// <summary>
    /// Model SinhVien - Lab 04: ASP.NET Core Model với Data Annotations
    /// </summary>
    public class CnttSinhVien
    {
        [Key]
        public int MaSV { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(15, MinimumLength = 10,
            ErrorMessage = "Số điện thoại phải từ 10 đến 15 ký tự")]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lớp không được để trống")]
        [Display(Name = "Lớp")]
        public string Lop { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngành không được để trống")]
        [Display(Name = "Ngành học")]
        public string Nganh { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; } = new DateTime(2000, 1, 1);

        [Range(0.0, 10.0, ErrorMessage = "Điểm TB phải từ 0 đến 10")]
        [Display(Name = "Điểm trung bình")]
        public double DiemTB { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(300, ErrorMessage = "Địa chỉ tối đa 300 ký tự")]
        public string? DiaChi { get; set; }

        // Thuộc tính tính toán
        [Display(Name = "Xếp loại")]
        public string XepLoai
        {
            get
            {
                if (DiemTB >= 9.0) return "Xuất sắc";
                if (DiemTB >= 8.0) return "Giỏi";
                if (DiemTB >= 6.5) return "Khá";
                if (DiemTB >= 5.0) return "Trung bình";
                return "Yếu";
            }
        }
    }
}
