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
    public class LocalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Locales.Include(l => l.Ciudad).Include(l => l.Responsable);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Locals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locales
                .Include(l => l.Ciudad)
                .Include(l => l.Responsable)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // GET: Locals/Create
        public IActionResult Create()
        {
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "Id", "Nombre");
            ViewData["ResponsableId"] = new SelectList(_context.Responsables, "Id", "Nombre");
            return View();
        }

        // POST: Locals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CiudadId,Direccion,Telefono,ResponsableId")] Local local)
        {
            // Validar si el responsable ya tiene un local asignado
            var responsable = await _context.Responsables
                .Include(r => r.Locales)
                .FirstOrDefaultAsync(r => r.Id == local.ResponsableId);

            if (responsable != null && responsable.Locales != null && responsable.Locales.Any())
            {
                ModelState.AddModelError("ResponsableId", "Este responsable ya tiene un local asignado.");
            }
            if (ModelState.IsValid)
            {
                _context.Add(local);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "Id", "Nombre", local.CiudadId);
            ViewData["ResponsableId"] = new SelectList(_context.Responsables, "Id", "Nombre", local.ResponsableId);
            return View(local);
        }

        // GET: Locals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locales.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "Id", "Nombre", local.CiudadId);
            ViewData["ResponsableId"] = new SelectList(_context.Responsables, "Id", "Nombre", local.ResponsableId);
            return View(local);
        }

        // POST: Locals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CiudadId,Direccion,Telefono,ResponsableId")] Local local)
        {
            if (id != local.Id)
            {
                return NotFound();
            }

            // Validar si el responsable ya tiene un local asignado
            var responsable = await _context.Responsables
                .Include(r => r.Locales)
                .FirstOrDefaultAsync(r => r.Id == local.ResponsableId);

            if (responsable != null && responsable.Locales != null && responsable.Locales.Any())
            {
                ModelState.AddModelError("ResponsableId", "Este responsable ya tiene un local asignado.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalExists(local.Id))
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
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "Id", "Nombre", local.CiudadId);
            ViewData["ResponsableId"] = new SelectList(_context.Responsables, "Id", "Nombre", local.ResponsableId);
            return View(local);
        }

        // GET: Locals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locales
                .Include(l => l.Ciudad)
                .Include(l => l.Responsable)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var local = await _context.Locales.FindAsync(id);
            if (local != null)
            {
                _context.Locales.Remove(local);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(int id)
        {
            return _context.Locales.Any(e => e.Id == id);
        }
    }
}
