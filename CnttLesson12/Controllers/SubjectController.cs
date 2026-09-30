using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CnttLesson12.Data;
using CnttLesson12.Models;

namespace CnttLesson12.Controllers
{
    public class SubjectController : Controller
    {
        private readonly AppDbContext _context;

        public SubjectController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var subject = await _context.Subjects
                .Include(s => s.Marks!)
                    .ThenInclude(m => m.Student)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (subject == null) return NotFound();

            return View(subject);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectName")] Subject subject)
        {
            // Kiểm tra trùng tên môn học
            if (await _context.Subjects.AnyAsync(s => s.SubjectName == subject.SubjectName))
            {
                ModelState.AddModelError("SubjectName", "Tên môn học đã tồn tại trong hệ thống");
            }

            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null) return NotFound();

            return View(subject);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectName")] Subject subject)
        {
            if (id != subject.Id) return NotFound();

            // Kiểm tra trùng tên môn học
            if (await _context.Subjects.AnyAsync(s => s.SubjectName == subject.SubjectName && s.Id != id))
            {
                ModelState.AddModelError("SubjectName", "Tên môn học đã tồn tại trong hệ thống");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Subjects.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);

            if (subject == null) return NotFound();

            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
                _context.Subjects.Remove(subject);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
