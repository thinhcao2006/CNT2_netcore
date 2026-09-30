using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CnttLesson12.Data;
using CnttLesson12.Models;

namespace CnttLesson12.Controllers
{
    public class StdClassController : Controller
    {
        private readonly AppDbContext _context;

        public StdClassController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StdClass
        public async Task<IActionResult> Index()
        {
            return View(await _context.StdClasses.ToListAsync());
        }

        // GET: StdClass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var stdClass = await _context.StdClasses
                .Include(c => c.Students)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (stdClass == null) return NotFound();

            return View(stdClass);
        }

        // GET: StdClass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StdClass/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassName")] StdClass stdClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stdClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stdClass);
        }

        // GET: StdClass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var stdClass = await _context.StdClasses.FindAsync(id);
            if (stdClass == null) return NotFound();

            return View(stdClass);
        }

        // POST: StdClass/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassName")] StdClass stdClass)
        {
            if (id != stdClass.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stdClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.StdClasses.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stdClass);
        }

        // GET: StdClass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var stdClass = await _context.StdClasses
                .FirstOrDefaultAsync(m => m.Id == id);

            if (stdClass == null) return NotFound();

            return View(stdClass);
        }

        // POST: StdClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stdClass = await _context.StdClasses.FindAsync(id);
            if (stdClass != null)
                _context.StdClasses.Remove(stdClass);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
