using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CameraTrackerApp.Models;

namespace CameraTrackerApp.Controllers
{
    public class ConfirmationController : Controller
    {
        private readonly Context _context;

        public ConfirmationController(Context context)
        {
            _context = context;
        }

        // GET: Confirmation
        public async Task<IActionResult> Index()
        {
              return View(await _context.Confirmation.ToListAsync());
        }

        // GET: Confirmation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Confirmation == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmation
                .FirstOrDefaultAsync(m => m.ID == id);
            if (confirmation == null)
            {
                return NotFound();
            }

            return View(confirmation);
        }

        // GET: Confirmation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confirmation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,CameraID,Description,Approved,Rejected,ConfirmationDateTime")] Confirmation confirmation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confirmation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confirmation);
        }

        // GET: Confirmation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Confirmation == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmation.FindAsync(id);
            if (confirmation == null)
            {
                return NotFound();
            }
            return View(confirmation);
        }

        // POST: Confirmation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,CameraID,Description,Approved,Rejected,ConfirmationDateTime")] Confirmation confirmation)
        {
            if (id != confirmation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confirmation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfirmationExists(confirmation.ID))
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
            return View(confirmation);
        }

        // GET: Confirmation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Confirmation == null)
            {
                return NotFound();
            }

            var confirmation = await _context.Confirmation
                .FirstOrDefaultAsync(m => m.ID == id);
            if (confirmation == null)
            {
                return NotFound();
            }

            return View(confirmation);
        }

        // POST: Confirmation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Confirmation == null)
            {
                return Problem("Entity set 'Context.Confirmation'  is null.");
            }
            var confirmation = await _context.Confirmation.FindAsync(id);
            if (confirmation != null)
            {
                _context.Confirmation.Remove(confirmation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfirmationExists(int id)
        {
          return _context.Confirmation.Any(e => e.ID == id);
        }
    }
}
