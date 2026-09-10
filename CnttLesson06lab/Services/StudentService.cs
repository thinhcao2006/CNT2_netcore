using CnttLesson06lab.Models;

namespace CnttLesson06lab.Services
{
    public class StudentService
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { StudentId = 1, FullName = "Nguyễn Văn An", DateOfBirth = new DateTime(2003, 5, 15), Email = "nguyenvanan@email.com", Phone = "0901234567", ClassName = "CNT2A", Gender = "Nam", GPA = 3.7 },
            new Student { StudentId = 2, FullName = "Trần Thị Bích", DateOfBirth = new DateTime(2003, 8, 22), Email = "tranthibich@email.com", Phone = "0912345678", ClassName = "CNT2A", Gender = "Nữ", GPA = 3.4 },
            new Student { StudentId = 3, FullName = "Lê Văn Cường", DateOfBirth = new DateTime(2002, 12, 10), Email = "levancuong@email.com", Phone = "0923456789", ClassName = "CNT2B", Gender = "Nam", GPA = 2.8 },
            new Student { StudentId = 4, FullName = "Phạm Thị Dung", DateOfBirth = new DateTime(2003, 3, 7), Email = "phamthidung@email.com", Phone = "0934567890", ClassName = "CNT2B", Gender = "Nữ", GPA = 3.1 },
            new Student { StudentId = 5, FullName = "Hoàng Văn Em", DateOfBirth = new DateTime(2002, 7, 30), Email = "hoangvanem@email.com", Phone = "0945678901", ClassName = "CNT2C", Gender = "Nam", GPA = 2.3 },
            new Student { StudentId = 6, FullName = "Vũ Thị Phương", DateOfBirth = new DateTime(2003, 1, 18), Email = "vuthiphuong@email.com", Phone = "0956789012", ClassName = "CNT2C", Gender = "Nữ", GPA = 3.9 },
        };

        private static int _nextId = 7;

        public List<Student> GetAll() => _students.ToList();

        public List<Student> Search(string? keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _students.ToList();

            keyword = keyword.ToLower().Trim();
            return _students.Where(s =>
                s.FullName.ToLower().Contains(keyword) ||
                s.StudentId.ToString().Contains(keyword) ||
                s.Email.ToLower().Contains(keyword) ||
                s.ClassName.ToLower().Contains(keyword) ||
                s.Phone.Contains(keyword)
            ).ToList();
        }

        public Student? GetById(int id) => _students.FirstOrDefault(s => s.StudentId == id);

        public void Add(Student student)
        {
            student.StudentId = _nextId++;
            _students.Add(student);
        }

        public bool Update(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existing == null) return false;

            existing.FullName = student.FullName;
            existing.DateOfBirth = student.DateOfBirth;
            existing.Email = student.Email;
            existing.Phone = student.Phone;
            existing.ClassName = student.ClassName;
            existing.Gender = student.Gender;
            existing.GPA = student.GPA;
            return true;
        }

        public bool Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student == null) return false;
            _students.Remove(student);
            return true;
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            return _students.Any(s => s.Email.ToLower() == email.ToLower() && s.StudentId != excludeId);
        }
    }
}
