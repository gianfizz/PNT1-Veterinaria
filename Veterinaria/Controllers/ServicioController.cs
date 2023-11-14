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
    public class ServicioController : Controller
    {
        private readonly VeterinariaDatabaseContext _context;

        public ServicioController(VeterinariaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Servicio
        public async Task<IActionResult> Index()
        {
            return _context.Servicios != null ?
                View(await _context.Servicios.ToListAsync()) :
                Problem("Entity set 'VeterinariaDatabaseContext.Servicios'  is null.");
        }

        // GET: Servicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // GET: Servicio/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nombre");
            ViewBag.Doctores = new SelectList(await _context.Doctores.ToListAsync(), "Id", "Nombre");

            return View();
        }

        // POST: Servicio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,DoctorId,Fecha,DetalleServicio")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recargar las SelectList en caso de error
            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nombre", servicio.ClienteId);
            ViewBag.Doctores = new SelectList(await _context.Doctores.ToListAsync(), "Id", "Nombre", servicio.DoctorId);

            return View("Create", servicio); // Renombrar la vista "Create"
        }

        // GET: Servicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nombre", servicio.ClienteId);
            ViewBag.Doctores = new SelectList(await _context.Doctores.ToListAsync(), "Id", "Nombre", servicio.DoctorId);

            return View(servicio);
        }

        // POST: Servicio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,DoctorId,Fecha,DetalleServicio")] Servicio servicio)
        {
            if (id != servicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioExists(servicio.Id))
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

            ViewBag.Clientes = new SelectList(await _context.Clientes.ToListAsync(), "Id", "Nombre", servicio.ClienteId);
            ViewBag.Doctores = new SelectList(await _context.Doctores.ToListAsync(), "Id", "Nombre", servicio.DoctorId);

            return View(servicio);
        }

        // GET: Servicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicios == null)
            {
                return Problem("Entity set 'VeterinariaDatabaseContext.Servicios'  is null.");
            }

            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioExists(int id)
        {
            return (_context.Servicios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
