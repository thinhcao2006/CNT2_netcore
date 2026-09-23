using CnttLesson09Annotation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson09Annotation.Controllers
{
    public class TvcStudentController : Controller
    {
        // Dữ liệu mẫu lưu trong memory (thay bằng database thực tế nếu cần)
        private static List<TvcStudent> _students = new List<TvcStudent>
        {
            new TvcStudent { TvcStudentId = 1, TvcStudentCode = "SV001", TvcFullName = "Nguyễn Văn An", TvcEmail = "an@email.com", TvcPhone = "0901234567", TvcMajor = "Công nghệ thông tin", TvcBirthday = new DateTime(2002, 5, 15), TvcYear = 3 },
            new TvcStudent { TvcStudentId = 2, TvcStudentCode = "SV002", TvcFullName = "Trần Thị Bình", TvcEmail = "binh@email.com", TvcPhone = "0912345678", TvcMajor = "Kỹ thuật phần mềm", TvcBirthday = new DateTime(2003, 8, 20), TvcYear = 2 },
            new TvcStudent { TvcStudentId = 3, TvcStudentCode = "SV003", TvcFullName = "Lê Văn Cường", TvcEmail = "cuong@email.com", TvcPhone = "0923456789", TvcMajor = "Hệ thống thông tin", TvcBirthday = new DateTime(2001, 3, 10), TvcYear = 4 },
        };
        private static int _nextId = 4;

        // GET: TvcStudent
        public IActionResult Index()
        {
            return View(_students);
        }

        // GET: TvcStudent/Details/5
        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.TvcStudentId == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // GET: TvcStudent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvcStudent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TvcStudent student)
        {
            if (ModelState.IsValid)
            {
                student.TvcStudentId = _nextId++;
                _students.Add(student);
                TempData["Success"] = "Thêm sinh viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: TvcStudent/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _students.FirstOrDefault(s => s.TvcStudentId == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: TvcStudent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TvcStudent student)
        {
            if (ModelState.IsValid)
            {
                var existing = _students.FirstOrDefault(s => s.TvcStudentId == id);
                if (existing == null) return NotFound();
                existing.TvcStudentCode = student.TvcStudentCode;
                existing.TvcFullName = student.TvcFullName;
                existing.TvcEmail = student.TvcEmail;
                existing.TvcPhone = student.TvcPhone;
                existing.TvcMajor = student.TvcMajor;
                existing.TvcBirthday = student.TvcBirthday;
                existing.TvcYear = student.TvcYear;
                TempData["Success"] = "Cập nhật sinh viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: TvcStudent/Delete/5
        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.TvcStudentId == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: TvcStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _students.FirstOrDefault(s => s.TvcStudentId == id);
            if (student != null)
            {
                _students.Remove(student);
                TempData["Success"] = "Xóa sinh viên thành công!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
