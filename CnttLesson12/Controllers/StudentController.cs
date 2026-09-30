using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CnttLesson12.Data;
using CnttLesson12.Models;

namespace CnttLesson12.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var students = _context.Students.Include(s => s.StdClass);
            return View(await students.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .Include(s => s.StdClass)
                .Include(s => s.Marks!)
                    .ThenInclude(m => m.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.StdClasses, "Id", "ClassName");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,StudentEmail,StudentPhone,StudentAddress,StudentBirthday,ClassId")] Student student, IFormFile? avatarFile)
        {
            // Kiểm tra trùng email
            if (await _context.Students.AnyAsync(s => s.StudentEmail == student.StudentEmail))
            {
                ModelState.AddModelError("StudentEmail", "Email đã tồn tại trong hệ thống");
            }

            // Kiểm tra trùng số điện thoại
            if (await _context.Students.AnyAsync(s => s.StudentPhone == student.StudentPhone))
            {
                ModelState.AddModelError("StudentPhone", "Số điện thoại đã tồn tại trong hệ thống");
            }

            if (ModelState.IsValid)
            {
                // Upload avatar
                if (avatarFile != null && avatarFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatars");
                    Directory.CreateDirectory(uploadsFolder);
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(avatarFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await avatarFile.CopyToAsync(fileStream);
                    }
                    student.StudentAvatar = "/images/avatars/" + uniqueFileName;
                }
                else
                {
                    student.StudentAvatar = "/images/avatars/default.png";
                }

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClassId"] = new SelectList(_context.StdClasses, "Id", "ClassName", student.ClassId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            ViewData["ClassId"] = new SelectList(_context.StdClasses, "Id", "ClassName", student.ClassId);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,StudentEmail,StudentPhone,StudentAddress,StudentAvatar,StudentBirthday,ClassId")] Student student, IFormFile? avatarFile)
        {
            if (id != student.Id) return NotFound();

            // Kiểm tra trùng email (ngoại trừ chính sinh viên này)
            if (await _context.Students.AnyAsync(s => s.StudentEmail == student.StudentEmail && s.Id != id))
            {
                ModelState.AddModelError("StudentEmail", "Email đã được sử dụng bởi sinh viên khác");
            }

            // Kiểm tra trùng số điện thoại
            if (await _context.Students.AnyAsync(s => s.StudentPhone == student.StudentPhone && s.Id != id))
            {
                ModelState.AddModelError("StudentPhone", "Số điện thoại đã được sử dụng bởi sinh viên khác");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Upload avatar mới nếu có
                    if (avatarFile != null && avatarFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatars");
                        Directory.CreateDirectory(uploadsFolder);
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(avatarFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await avatarFile.CopyToAsync(fileStream);
                        }
                        student.StudentAvatar = "/images/avatars/" + uniqueFileName;
                    }
                    else
                    {
                        // Giữ nguyên avatar cũ
                        var existing = await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
                        if (existing != null)
                        {
                            student.StudentAvatar = existing.StudentAvatar;
                        }
                    }

                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Students.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClassId"] = new SelectList(_context.StdClasses, "Id", "ClassName", student.ClassId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .Include(s => s.StdClass)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
                _context.Students.Remove(student);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
