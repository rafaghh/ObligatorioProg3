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
    public class TipoRutinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoRutinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoRutinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposRutina.ToListAsync());
        }

        // GET: TipoRutinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRutina = await _context.TiposRutina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoRutina == null)
            {
                return NotFound();
            }

            return View(tipoRutina);
        }

        // GET: TipoRutinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRutinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoRutina tipoRutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoRutina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRutina);
        }

        // GET: TipoRutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRutina = await _context.TiposRutina.FindAsync(id);
            if (tipoRutina == null)
            {
                return NotFound();
            }
            return View(tipoRutina);
        }

        // POST: TipoRutinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoRutina tipoRutina)
        {
            if (id != tipoRutina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRutina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRutinaExists(tipoRutina.Id))
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
            return View(tipoRutina);
        }

        // GET: TipoRutinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRutina = await _context.TiposRutina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoRutina == null)
            {
                return NotFound();
            }

            return View(tipoRutina);
        }

        // POST: TipoRutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoRutina = await _context.TiposRutina.FindAsync(id);
            if (tipoRutina != null)
            {
                _context.TiposRutina.Remove(tipoRutina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRutinaExists(int id)
        {
            return _context.TiposRutina.Any(e => e.Id == id);
        }
    }
}
