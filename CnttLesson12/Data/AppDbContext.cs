using Microsoft.EntityFrameworkCore;
using CnttLesson12.Models;

namespace CnttLesson12.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Bài 1 - Category & Product
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Bài tập tự làm - Quản lý sinh viên (Student Manager)
        public DbSet<StdClass> StdClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ Product - Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ Student - StdClass
            modelBuilder.Entity<Student>()
                .HasOne(s => s.StdClass)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ràng buộc không trùng (Unique Index) theo yêu cầu đề bài
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentEmail)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentPhone)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                .HasIndex(s => s.SubjectName)
                .IsUnique();

            // Cấu hình Khóa chính trên 2 cột (SubjectId, StudentId) cho bảng Marks
            modelBuilder.Entity<Mark>()
                .HasKey(m => new { m.SubjectId, m.StudentId });

            // Cấu hình quan hệ Mark - Student
            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ Mark - Subject
            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Subject)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
