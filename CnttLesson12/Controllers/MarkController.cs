using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CnttLesson12.Data;
using CnttLesson12.Models;

namespace CnttLesson12.Controllers
{
    public class MarkController : Controller
    {
        private readonly AppDbContext _context;

        public MarkController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Mark
        public async Task<IActionResult> Index()
        {
            var marks = _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject);
            return View(await marks.ToListAsync());
        }

        // GET: Mark/Details?subjectId=1&studentId=2
        public async Task<IActionResult> Details(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null) return NotFound();

            var mark = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.SubjectId == subjectId && m.StudentId == studentId);

            if (mark == null) return NotFound();

            return View(mark);
        }

        // GET: Mark/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentName");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName");
            return View();
        }

        // POST: Mark/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,SubjectId,Score")] Mark mark)
        {
            // Kiểm tra trùng khóa chính (SubjectId, StudentId)
            bool exists = await _context.Marks.AnyAsync(m => m.SubjectId == mark.SubjectId && m.StudentId == mark.StudentId);
            if (exists)
            {
                ModelState.AddModelError(string.Empty, "Sinh viên này đã có điểm môn học đã chọn. Hãy chọn Chỉnh sửa nếu muốn cập nhật điểm!");
            }

            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "StudentName", mark.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", mark.SubjectId);
            return View(mark);
        }

        // GET: Mark/Edit?subjectId=1&studentId=2
        public async Task<IActionResult> Edit(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null) return NotFound();

            var mark = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.SubjectId == subjectId && m.StudentId == studentId);

            if (mark == null) return NotFound();

            return View(mark);
        }

        // POST: Mark/Edit?subjectId=1&studentId=2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int subjectId, int studentId, [Bind("SubjectId,StudentId,Score")] Mark mark)
        {
            if (subjectId != mark.SubjectId || studentId != mark.StudentId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Marks.AnyAsync(e => e.SubjectId == subjectId && e.StudentId == studentId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            mark.Student = await _context.Students.FindAsync(studentId);
            mark.Subject = await _context.Subjects.FindAsync(subjectId);
            return View(mark);
        }

        // GET: Mark/Delete?subjectId=1&studentId=2
        public async Task<IActionResult> Delete(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null) return NotFound();

            var mark = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.SubjectId == subjectId && m.StudentId == studentId);

            if (mark == null) return NotFound();

            return View(mark);
        }

        // POST: Mark/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int subjectId, int studentId)
        {
            var mark = await _context.Marks.FirstOrDefaultAsync(m => m.SubjectId == subjectId && m.StudentId == studentId);
            if (mark != null)
            {
                _context.Marks.Remove(mark);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
