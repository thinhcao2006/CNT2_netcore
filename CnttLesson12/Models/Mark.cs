using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CnttLesson12.Models
{
    public class Mark
    {
        // Khóa chính tổng hợp 2 cột (SubjectId, StudentId) theo đúng yêu cầu đề bài
        // Được cấu hình trong AppDbContext.OnModelCreating

        // Foreign Key Student
        [Display(Name = "Sinh viên")]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        // Foreign Key Subject
        [Display(Name = "Môn học")]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }

        [Column(TypeName = "float")]
        [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10")]
        [Display(Name = "Điểm")]
        public float Score { get; set; }
    }
}
