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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Socios.Include(s => s.Local).Include(s => s.TipoSocio);
            return View(await applicationDbContext.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("TipoId,LocalId,Id,Nombre,Telefono,Email")] Socio socio, List<int> RutinaId, List<int> Calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socio);
                await _context.SaveChangesAsync();

                // Agregar rutinas con calificación
                for (int i = 0; i < RutinaId.Count; i++)
                {
                    if (RutinaId[i] != 0)
                    {
                        _context.SocioRutinas.Add(new SocioRutina
                        {
                            SocioId = socio.Id,
                            RutinaId = RutinaId[i],
                            Calificacion = Calificacion[i]
                        });
                    }
                }
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

        // POST: Socios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,LocalId,Id,Nombre,Telefono,Email")] Socio socio, List<int> RutinaId, List<int> Calificacion)
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
        public async Task<IActionResult> AsignarRutina(int socioId, int rutinaId, int calificacion)
        {
            var socioRutina = new SocioRutina
            {
                SocioId = socioId,
                RutinaId = rutinaId,
                Calificacion = calificacion
            };

            _context.SocioRutinas.Add(socioRutina);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = socioId });
        }
    }
}