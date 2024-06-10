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
    public class TipoSociosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoSociosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoSocios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoSocio.ToListAsync());
        }

        // GET: TipoSocios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSocio = await _context.TipoSocio
                .FirstOrDefaultAsync(m => m.IdTipoSocio == id);
            if (tipoSocio == null)
            {
                return NotFound();
            }

            return View(tipoSocio);
        }

        // GET: TipoSocios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSocios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoSocio,TipoNombre,Beneficios")] TipoSocio tipoSocio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSocio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSocio);
        }

        // GET: TipoSocios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSocio = await _context.TipoSocio.FindAsync(id);
            if (tipoSocio == null)
            {
                return NotFound();
            }
            return View(tipoSocio);
        }

        // POST: TipoSocios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoSocio,TipoNombre,Beneficios")] TipoSocio tipoSocio)
        {
            if (id != tipoSocio.IdTipoSocio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSocio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSocioExists(tipoSocio.IdTipoSocio))
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
            return View(tipoSocio);
        }

        // GET: TipoSocios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSocio = await _context.TipoSocio
                .FirstOrDefaultAsync(m => m.IdTipoSocio == id);
            if (tipoSocio == null)
            {
                return NotFound();
            }

            return View(tipoSocio);
        }

        // POST: TipoSocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoSocio = await _context.TipoSocio.FindAsync(id);
            if (tipoSocio != null)
            {
                _context.TipoSocio.Remove(tipoSocio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSocioExists(int id)
        {
            return _context.TipoSocio.Any(e => e.IdTipoSocio == id);
        }
    }
}
