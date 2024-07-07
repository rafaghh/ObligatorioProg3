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
    public class MaquinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaquinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["FechaCompraSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fecha_desc" : "";
            ViewData["CurrentSort"] = sortOrder;

            var maquinas = from m in _context.Maquinas.Include(m => m.Local).Include(m => m.TipoMaquina)
                           select m;

            switch (sortOrder)
            {
                case "fecha_desc":
                    maquinas = maquinas.OrderByDescending(m => m.FechaCompra);
                    break;
                default:
                    maquinas = maquinas.OrderBy(m => m.FechaCompra);
                    break;
            }

            return View(await maquinas.ToListAsync());
        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas
                .Include(m => m.Local)
                .Include(m => m.TipoMaquina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            // Calcular los años de vida útil restantes
            int anosVidaUtilRestantes = maquina.VidaUtil - (DateTime.Now.Year - maquina.FechaCompra.Year);
            string vidaUtilMensaje = anosVidaUtilRestantes > 0 ? anosVidaUtilRestantes.ToString() : "Vida útil cumplida";
            ViewData["AnosVidaUtilRestantes"] = vidaUtilMensaje;

            return View(maquina);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            ViewData["LocalId"] = new SelectList(_context.Locales, "Id", "Nombre");
            ViewData["TipoMaquinaId"] = new SelectList(_context.TiposMaquina, "Id", "MaquinaNombre");
            return View();
        }

        // POST: Maquinas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocalId,FechaCompra,PrecioCompra,VidaUtil,TipoMaquinaId,Disponible")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalId"] = new SelectList(_context.Locales, "Id", "Nombre", maquina.LocalId);
            ViewData["TipoMaquinaId"] = new SelectList(_context.TiposMaquina, "Id", "MaquinaNombre", maquina.TipoMaquinaId);
            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }
            ViewData["LocalId"] = new SelectList(_context.Locales, "Id", "Nombre", maquina.LocalId);
            ViewData["TipoMaquinaId"] = new SelectList(_context.TiposMaquina, "Id", "MaquinaNombre", maquina.TipoMaquinaId);
            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocalId,FechaCompra,PrecioCompra,VidaUtil,TipoMaquinaId,Disponible")] Maquina maquina)
        {
            if (id != maquina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaExists(maquina.Id))
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
            ViewData["LocalId"] = new SelectList(_context.Locales, "Id", "Nombre", maquina.LocalId);
            ViewData["TipoMaquinaId"] = new SelectList(_context.TiposMaquina, "Id", "MaquinaNombre", maquina.TipoMaquinaId);
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas
                .Include(m => m.Local)
                .Include(m => m.TipoMaquina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina != null)
            {
                _context.Maquinas.Remove(maquina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(int id)
        {
            return _context.Maquinas.Any(e => e.Id == id);
        }
    
}
}
