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
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SociosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Socios
        public async Task<IActionResult> Index(int? tipoId)
        {
            var tiposSocio = await _context.TiposSocio.ToListAsync();
            ViewData["TipoId"] = new SelectList(tiposSocio, "Id", "TipoNombre");

            IQueryable<Socio> socios = _context.Socios.Include(s => s.Local).Include(s => s.TipoSocio);

            if (tipoId.HasValue)
            {
                socios = socios.Where(s => s.TipoId == tipoId);
            }

            return View(await socios.ToListAsync());
        }

        // GET: Socios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.Local)
                .Include(s => s.TipoSocio)
                .Include(s => s.SocioRutinas)
                .ThenInclude(sr => sr.Rutina)
                .Include(s => s.SocioRutinas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // GET: Socios/Create
        public IActionResult Create()
        {
            ViewData["LocalId"] = new SelectList(_context.Locales, "Id", "Nombre");
            ViewData["TipoId"] = new SelectList(_context.TiposSocio, "Id", "TipoNombre");
            ViewData["RutinaId"] = new SelectList(_context.Rutinas, "Id", "Descripcion");
            return View();
        }

        // POST: Socios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoId,LocalId,Id,Nombre,Telefono,Email")] Socio socio, List<int> RutinaId, List<int> Calificacion, List<int> MaquinaId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalId"] = new SelectList(_context.Locales, "Id", "Nombre", socio.LocalId);
            ViewData["TipoId"] = new SelectList(_context.TiposSocio, "Id", "TipoNombre", socio.TipoId);
            ViewData["RutinaId"] = new SelectList(_context.Rutinas, "Id", "Descripcion");
            return View(socio);
        }

        // GET: Socios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.SocioRutinas)
                .ThenInclude(sr => sr.Rutina)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (socio == null)
            {
                return NotFound();
            }
            ViewData["LocalId"] = new SelectList(_context.Locales, "Id", "Nombre", socio.LocalId);
            ViewData["TipoId"] = new SelectList(_context.TiposSocio, "Id", "TipoNombre", socio.TipoId);
            ViewData["RutinaId"] = new SelectList(_context.Rutinas, "Id", "Descripcion");
            return View(socio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,LocalId,Id,Nombre,Telefono,Email")] Socio socio, List<int> RutinaId, List<int> Calificacion, List<int> MaquinaId)
        {
            if (id != socio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocioExists(socio.Id))
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
            ViewData["LocalId"] = new SelectList(_context.Locales, "Id", "Nombre", socio.LocalId);
            ViewData["TipoId"] = new SelectList(_context.TiposSocio, "Id", "TipoNombre", socio.TipoId);
            ViewData["RutinaId"] = new SelectList(_context.Rutinas, "Id", "Descripcion");
            return View(socio);
        }

        // GET: Socios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.Local)
                .Include(s => s.TipoSocio)
                .Include(s => s.SocioRutinas)
                .ThenInclude(sr => sr.Rutina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socio = await _context.Socios.FindAsync(id);
            if (socio != null)
            {
                _context.Socios.Remove(socio);
                var socioRutinas = _context.SocioRutinas.Where(sr => sr.SocioId == id);
                _context.SocioRutinas.RemoveRange(socioRutinas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocioExists(int id)
        {
            return _context.Socios.Any(e => e.Id == id);
        }

        // POST: Socios/DesasignarRutina
        [HttpPost]
        public async Task<IActionResult> DesasignarRutina(int socioId, int rutinaId)
        {
            var socioRutina = await _context.SocioRutinas
                .FirstOrDefaultAsync(sr => sr.SocioId == socioId && sr.RutinaId == rutinaId);

            if (socioRutina != null)
            {
                _context.SocioRutinas.Remove(socioRutina);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id = socioId });
        }

        // POST: Socios/AsignarRutina
        [HttpPost]
        public async Task<IActionResult> AsignarRutina(int socioId, int rutinaId, int calificacion, int maquinaId)
        {
            var socio = await _context.Socios.FindAsync(socioId);

            // Comprobar si la rutina ya está asignada al socio
            var existingSocioRutina = await _context.SocioRutinas
                .FirstOrDefaultAsync(sr => sr.SocioId == socioId && sr.RutinaId == rutinaId);

            if (existingSocioRutina != null)
            {
                // La rutina ya está asignada
                TempData["ErrorMessage"] = "La rutina ya está asignada a este socio.";
                return RedirectToAction(nameof(Edit), new { id = socioId });
            }

            var socioRutina = new SocioRutina
            {
                SocioId = socioId,
                RutinaId = rutinaId,
                Calificacion = calificacion,
            };

            _context.SocioRutinas.Add(socioRutina);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = socioId });
        }
    }
}
