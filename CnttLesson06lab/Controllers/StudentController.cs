using CnttLesson06lab.Models;
using CnttLesson06lab.Services;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson06lab.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: /Student
        public IActionResult Index(string? search, string? filterClass)
        {
            ViewBag.SearchKeyword = search;
            ViewBag.FilterClass = filterClass;

            var students = _studentService.Search(search);

            if (!string.IsNullOrWhiteSpace(filterClass))
                students = students.Where(s => s.ClassName == filterClass).ToList();

            return View(students);
        }

        // GET: /Student/Details/5
        public IActionResult Details(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                TempData["Error"] = $"Không tìm thấy sinh viên có mã #{id}.";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (_studentService.EmailExists(student.Email))
            {
                ModelState.AddModelError("Email", "Email này đã được sử dụng bởi sinh viên khác.");
            }

            if (ModelState.IsValid)
            {
                _studentService.Add(student);
                TempData["Success"] = $"Đã thêm sinh viên '{student.FullName}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: /Student/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                TempData["Error"] = $"Không tìm thấy sinh viên có mã #{id}.";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentId)
                return BadRequest();

            if (_studentService.EmailExists(student.Email, student.StudentId))
            {
                ModelState.AddModelError("Email", "Email này đã được sử dụng bởi sinh viên khác.");
            }

            if (ModelState.IsValid)
            {
                bool updated = _studentService.Update(student);
                if (!updated)
                {
                    TempData["Error"] = "Không tìm thấy sinh viên để cập nhật.";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Success"] = $"Đã cập nhật thông tin sinh viên '{student.FullName}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public IActionResult Delete(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                TempData["Error"] = $"Không tìm thấy sinh viên có mã #{id}.";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _studentService.GetById(id);
            string name = student?.FullName ?? $"#{id}";
            bool deleted = _studentService.Delete(id);
            if (deleted)
                TempData["Success"] = $"Đã xóa sinh viên '{name}' thành công!";
            else
                TempData["Error"] = "Không tìm thấy sinh viên để xóa.";
            return RedirectToAction(nameof(Index));
        }
    }
}
