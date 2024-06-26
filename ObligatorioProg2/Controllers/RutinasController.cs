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
                .Include(r => r.RutinaEjercicios)
                .ThenInclude(re => re.Ejercicio)
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

            var rutina = await _context.Rutinas
                .Include(r => r.RutinaEjercicios)
                .ThenInclude(re => re.Ejercicio)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rutina == null)
            {
                return NotFound();
            }

            ViewData["TipoRutinaId"] = new SelectList(_context.TiposRutina, "Id", "Nombre", rutina.TipoRutinaId);
            ViewData["Ejercicios"] = new SelectList(_context.Ejercicios, "Id", "Descripcion");

            return View(rutina);
        }

        // POST: Rutinas/Edit/5
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
            ViewData["Ejercicios"] = new SelectList(_context.Ejercicios, "Id", "Descripcion");

            return View(rutina);
        }

        // POST: Rutinas/AsignarEjercicio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarEjercicio(int rutinaId, int ejercicioId)
        {
            if (!RutinaExists(rutinaId))
            {
                return NotFound();
            }

            if (_context.RutinaEjercicios.Any(re => re.RutinaId == rutinaId && re.EjercicioId == ejercicioId))
            {
                ModelState.AddModelError("", "El ejercicio ya está asignado a esta rutina.");

                // Recargar la vista Edit con el error
                var rutina = await _context.Rutinas
                    .Include(r => r.RutinaEjercicios)
                    .ThenInclude(re => re.Ejercicio)
                    .FirstOrDefaultAsync(m => m.Id == rutinaId);

                ViewData["TipoRutinaId"] = new SelectList(_context.TiposRutina, "Id", "Nombre", rutina.TipoRutinaId);
                ViewData["Ejercicios"] = new SelectList(_context.Ejercicios, "Id", "Descripcion");
                return View("Edit", rutina);
            }

            var rutinaEjercicio = new RutinaEjercicio
            {
                RutinaId = rutinaId,
                EjercicioId = ejercicioId
            };

            _context.RutinaEjercicios.Add(rutinaEjercicio);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = rutinaId });
        }

        // POST: Rutinas/DesasignarEjercicio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesasignarEjercicio(int rutinaId, int ejercicioId)
        {
            var rutinaEjercicio = await _context.RutinaEjercicios
                .FirstOrDefaultAsync(re => re.RutinaId == rutinaId && re.EjercicioId == ejercicioId);

            if (rutinaEjercicio == null)
            {
                return NotFound();
            }

            _context.RutinaEjercicios.Remove(rutinaEjercicio);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = rutinaId });
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
