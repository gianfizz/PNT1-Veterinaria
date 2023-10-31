using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Context;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    public class VeterinariaController : Controller
    {
        private readonly VeterinariaDatabaseContext _context;

        public VeterinariaController(VeterinariaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Veterinaria
        public async Task<IActionResult> Index()
        {
              return _context.Veterinarias != null ? 
                          View(await _context.Veterinarias.ToListAsync()) :
                          Problem("Entity set 'VeterinariaDatabaseContext.Veterinarias'  is null.");
        }

        // GET: Veterinaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Veterinarias == null)
            {
                return NotFound();
            }

            var veterinarias = await _context.Veterinarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinarias == null)
            {
                return NotFound();
            }

            return View(veterinarias);
        }

        // GET: Veterinaria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Veterinarias veterinarias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinarias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinarias);
        }

        // GET: Veterinaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Veterinarias == null)
            {
                return NotFound();
            }

            var veterinarias = await _context.Veterinarias.FindAsync(id);
            if (veterinarias == null)
            {
                return NotFound();
            }
            return View(veterinarias);
        }

        // POST: Veterinaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Veterinarias veterinarias)
        {
            if (id != veterinarias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinarias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinariasExists(veterinarias.Id))
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
            return View(veterinarias);
        }

        // GET: Veterinaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Veterinarias == null)
            {
                return NotFound();
            }

            var veterinarias = await _context.Veterinarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinarias == null)
            {
                return NotFound();
            }

            return View(veterinarias);
        }

        // POST: Veterinaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Veterinarias == null)
            {
                return Problem("Entity set 'VeterinariaDatabaseContext.Veterinarias'  is null.");
            }
            var veterinarias = await _context.Veterinarias.FindAsync(id);
            if (veterinarias != null)
            {
                _context.Veterinarias.Remove(veterinarias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinariasExists(int id)
        {
          return (_context.Veterinarias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
