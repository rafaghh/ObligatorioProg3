using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Datos;
using ObligatorioProg3.Models;

namespace ObligatorioProg3.Controllers
{
    public class RutinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RutinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rutinas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rutinas.Include(r => r.TipoRutina);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rutinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
                .Include(r => r.TipoRutina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // GET: Rutinas/Create
        public IActionResult Create()
        {
            ViewData["TipoRutinaId"] = new SelectList(_context.TiposRutina, "Id", "Nombre");
            return View();
        }

        // POST: Rutinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Calificacion,TipoRutinaId")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rutina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoRutinaId"] = new SelectList(_context.TiposRutina, "Id", "Nombre", rutina.TipoRutinaId);
            return View(rutina);
        }

        // GET: Rutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }
            ViewData["TipoRutinaId"] = new SelectList(_context.TiposRutina, "Id", "Nombre", rutina.TipoRutinaId);
            return View(rutina);
        }

        // POST: Rutinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Calificacion,TipoRutinaId")] Rutina rutina)
        {
            if (id != rutina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rutina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutinaExists(rutina.Id))
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
            ViewData["TipoRutinaId"] = new SelectList(_context.TiposRutina, "Id", "Nombre", rutina.TipoRutinaId);
            return View(rutina);
        }

        // GET: Rutinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
                .Include(r => r.TipoRutina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // POST: Rutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina != null)
            {
                _context.Rutinas.Remove(rutina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutinaExists(int id)
        {
            return _context.Rutinas.Any(e => e.Id == id);
        }
    }
}
