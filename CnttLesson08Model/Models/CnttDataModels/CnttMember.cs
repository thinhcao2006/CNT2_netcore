using System.ComponentModel.DataAnnotations;

namespace CnttLesson08Model.Models.CnttDataModels
{
    public class CnttMember
    {
        [Display(Name = "Mã sinh viên")]
        public string CnttMemberId { get; set; } = string.Empty;

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string CnttUserName { get; set; } = string.Empty;

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string CnttPassword { get; set; } = string.Empty;

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        public string CnttFullName { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [DataType(DataType.EmailAddress)]
        public string CnttEmail { get; set; } = string.Empty;

        // Các thuộc tính ánh xạ tương thích tuyệt đối với slide (MemberId, Username, Password, Fullname, Email)
        public string MemberId
        {
            get => CnttMemberId;
            set => CnttMemberId = value;
        }

        public string Username
        {
            get => CnttUserName;
            set => CnttUserName = value;
        }

        public string Password
        {
            get => CnttPassword;
            set => CnttPassword = value;
        }

        public string Fullname
        {
            get => CnttFullName;
            set => CnttFullName = value;
        }

        public string FullName
        {
            get => CnttFullName;
            set => CnttFullName = value;
        }

        public string Email
        {
            get => CnttEmail;
            set => CnttEmail = value;
        }
    }

    /// <summary>
    /// Alias Member kế thừa CnttMember để tương thích tuyệt đối với code mẫu trong Slide
    /// </summary>
    public class Member : CnttMember
    {
    }

    /// <summary>
    /// Alias SinhVien cho chức năng sinh viên
    /// </summary>
    public class SinhVien : CnttMember
    {
    }
}
