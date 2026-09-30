using CnttLesson12.Models;

namespace CnttLesson12.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // 1. Seed Categories & Products nếu chưa có
            if (!context.Categories.Any())
            {
                var catAoNam = new Category { Name = "Áo nam", Status = 1, CreatedDate = DateTime.Now };
                var catAoNu = new Category { Name = "Áo nữ", Status = 1, CreatedDate = DateTime.Now };
                var catPhuKien = new Category { Name = "Phụ kiện", Status = 1, CreatedDate = DateTime.Now };

                context.Categories.AddRange(catAoNam, catAoNu, catPhuKien);
                context.SaveChanges();

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Áo sơ mi nam Oxford",
                        Price = 350000,
                        Status = 1,
                        Description = "Áo sơ mi nam chất liệu cotton cao cấp, thoáng mát",
                        CategoryId = catAoNam.Id,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        Name = "Áo thun Polo thể thao",
                        Price = 250000,
                        Status = 1,
                        Description = "Áo thun polo co giãn 4 chiều",
                        CategoryId = catAoNam.Id,
                        CreatedDate = DateTime.Now
                    },
                    new Product
                    {
                        Name = "Đầm suông công sở",
                        Price = 450000,
                        Status = 1,
                        Description = "Đầm suông thiết kế thanh lịch cho phái nữ",
                        CategoryId = catAoNu.Id,
                        CreatedDate = DateTime.Now
                    }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            // 2. Seed StdClasses (Lớp học)
            if (!context.StdClasses.Any())
            {
                var class1 = new StdClass { ClassName = "CNTT - K22A" };
                var class2 = new StdClass { ClassName = "CNTT - K22B" };
                var class3 = new StdClass { ClassName = "KTPM - K22" };

                context.StdClasses.AddRange(class1, class2, class3);
                context.SaveChanges();
            }

            // 3. Seed Subjects (Môn học)
            if (!context.Subjects.Any())
            {
                var sub1 = new Subject { SubjectName = "Lập trình C# nâng cao" };
                var sub2 = new Subject { SubjectName = "Phát triển Web ASP.NET Core MVC" };
                var sub3 = new Subject { SubjectName = "Cơ sở dữ liệu SQL Server" };
                var sub4 = new Subject { SubjectName = "Cấu trúc dữ liệu và giải thuật" };

                context.Subjects.AddRange(sub1, sub2, sub3, sub4);
                context.SaveChanges();
            }

            // 4. Seed Students (Sinh viên)
            if (!context.Students.Any())
            {
                var firstClass = context.StdClasses.FirstOrDefault();
                if (firstClass != null)
                {
                    var std1 = new Student
                    {
                        StudentName = "Nguyễn Văn An",
                        StudentEmail = "an.nguyen@example.com",
                        StudentPhone = "0987654321",
                        StudentAddress = "Hà Nội",
                        StudentAvatar = "/images/avatars/default.png",
                        StudentBirthday = new DateTime(2003, 5, 15),
                        ClassId = firstClass.Id
                    };

                    var std2 = new Student
                    {
                        StudentName = "Trần Thị Bình",
                        StudentEmail = "binh.tran@example.com",
                        StudentPhone = "0912345678",
                        StudentAddress = "Hải Phòng",
                        StudentAvatar = "/images/avatars/default.png",
                        StudentBirthday = new DateTime(2003, 8, 20),
                        ClassId = firstClass.Id
                    };

                    context.Students.AddRange(std1, std2);
                    context.SaveChanges();

                    // 5. Seed Marks (Bảng điểm)
                    var subList = context.Subjects.Take(2).ToList();
                    if (subList.Count >= 2)
                    {
                        context.Marks.AddRange(
                            new Mark { StudentId = std1.Id, SubjectId = subList[0].Id, Score = 8.5f },
                            new Mark { StudentId = std1.Id, SubjectId = subList[1].Id, Score = 9.0f },
                            new Mark { StudentId = std2.Id, SubjectId = subList[0].Id, Score = 7.5f },
                            new Mark { StudentId = std2.Id, SubjectId = subList[1].Id, Score = 8.0f }
                        );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
