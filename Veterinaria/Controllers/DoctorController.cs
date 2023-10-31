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
    public class DoctorController : Controller
    {
        private readonly VeterinariaDatabaseContext _context;

        public DoctorController(VeterinariaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
              return _context.Doctores != null ? 
                          View(await _context.Doctores.ToListAsync()) :
                          Problem("Entity set 'VeterinariaDatabaseContext.Doctores'  is null.");
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctores == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctores == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctores.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doctores == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctores == null)
            {
                return Problem("Entity set 'VeterinariaDatabaseContext.Doctores'  is null.");
            }
            var doctor = await _context.Doctores.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctores.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
          return (_context.Doctores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
