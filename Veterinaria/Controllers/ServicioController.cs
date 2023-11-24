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
            var veterinariaDatabaseContext = _context.Servicios.Include(s => s.NombreCliente).Include(s => s.NombreDoctor);
            return View(await veterinariaDatabaseContext.ToListAsync());
        }

        // GET: Servicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .Include(s => s.NombreCliente)
                .Include(s => s.NombreDoctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // GET: Servicio/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido");
            ViewData["DoctorId"] = new SelectList(_context.Doctores, "Id", "Nombre");
            return View();
        }

        // POST: Servicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,DoctorId,Fecha,DetalleServicio")] Servicio servicio)
        {
            
            _context.Add(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", servicio.ClienteId);
            ViewData["DoctorId"] = new SelectList(_context.Doctores, "Id", "Nombre", servicio.DoctorId);
            return View(servicio);
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", servicio.ClienteId);
            ViewData["DoctorId"] = new SelectList(_context.Doctores, "Id", "Nombre", servicio.DoctorId);
            return View(servicio);
        }

        // POST: Servicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,DoctorId,Fecha,DetalleServicio")] Servicio servicio)
        {
            if (id != servicio.Id)
            {
                return NotFound();
            }

            
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Apellido", servicio.ClienteId);
            ViewData["DoctorId"] = new SelectList(_context.Doctores, "Id", "Nombre", servicio.DoctorId);
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
                .Include(s => s.NombreCliente)
                .Include(s => s.NombreDoctor)
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

        public IActionResult ListarPorCliente(int clienteId)
        {
             var serviciosCliente = _context.Servicios
            .Include(s => s.NombreDoctor)  // Asegúrate de incluir la relación con el Doctor
            .Where(s => s.ClienteId == clienteId)
            .ToList();

            return View(serviciosCliente);
        }

    }
        

}
