using System.ComponentModel.DataAnnotations;

namespace CnttLesson08Lab.Models
{
    /// <summary>
    /// Model SanPham (Sản phẩm) - Lab 04: ASP.NET Core Model với Data Annotations
    /// </summary>
    public class CnttSanPham
    {
        [Key]
        public int MaSP { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Tên sản phẩm phải từ 3 đến 100 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; } = string.Empty;

        [Required(ErrorMessage = "Loại sản phẩm không được để trống")]
        [Display(Name = "Loại sản phẩm")]
        public string LoaiSP { get; set; } = string.Empty;

        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Range(1000, 1000000000,
            ErrorMessage = "Đơn giá phải từ 1.000 đến 1.000.000.000 VNĐ")]
        [Display(Name = "Đơn giá (VNĐ)")]
        [DataType(DataType.Currency)]
        public decimal DonGia { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Range(0, 10000, ErrorMessage = "Số lượng phải từ 0 đến 10.000")]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(500, ErrorMessage = "Mô tả tối đa 500 ký tự")]
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Ngày nhập không được để trống")]
        [Display(Name = "Ngày nhập")]
        [DataType(DataType.Date)]
        public DateTime NgayNhap { get; set; } = DateTime.Today;

        // Thuộc tính tính toán (không lưu DB)
        [Display(Name = "Thành tiền")]
        public decimal ThanhTien => DonGia * SoLuong;
    }
}
