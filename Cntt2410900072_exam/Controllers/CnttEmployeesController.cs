
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cntt24109000_exam.Models;

public class CnttEmployeesController : Controller
{
    private readonly CnttContext _context;

    public CnttEmployeesController(CnttContext context)
    {
        _context = context;
    }

    // GET: CNTTEMPLOYEES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.CnttEmployees.ToListAsync());
    }

    // GET: CNTTEMPLOYEES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cnttemployee = await _context.CnttEmployees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cnttemployee == null)
        {
            return NotFound();
        }

        return View(cnttemployee);
    }

    // GET: CNTTEMPLOYEES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CNTTEMPLOYEES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CnttName,CnttGender,CnttBirthDay,CnttEmail,CnttPhone,CnttActive")] CnttEmployee cnttemployee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(cnttemployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cnttemployee);
    }

    // GET: CNTTEMPLOYEES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cnttemployee = await _context.CnttEmployees.FindAsync(id);
        if (cnttemployee == null)
        {
            return NotFound();
        }
        return View(cnttemployee);
    }

    // POST: CNTTEMPLOYEES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,CnttName,CnttGender,CnttBirthDay,CnttEmail,CnttPhone,CnttActive")] CnttEmployee cnttemployee)
    {
        if (id != cnttemployee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cnttemployee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnttEmployeeExists(cnttemployee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cnttemployee);
    }

    // GET: CNTTEMPLOYEES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cnttemployee = await _context.CnttEmployees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cnttemployee == null)
        {
            return NotFound();
        }

        return View(cnttemployee);
    }

    // POST: CNTTEMPLOYEES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var cnttemployee = await _context.CnttEmployees.FindAsync(id);
        if (cnttemployee != null)
        {
            _context.CnttEmployees.Remove(cnttemployee);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CnttEmployeeExists(int? id)
    {
        return _context.CnttEmployees.Any(e => e.Id == id);
    }
}
