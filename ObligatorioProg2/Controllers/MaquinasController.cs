﻿using System;
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Maquina.ToListAsync());
        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .FirstOrDefaultAsync(m => m.IdMaquina == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            ViewData["TipoMaquina"] = new SelectList(_context.TipoMaquina, "IdTipoMaq", "MaquinaNombre");
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaquina,FechaCompra,PrecioCompra,VidaUtil,Disponible,TipoMId")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoMaquina"] = new SelectList(_context.TipoMaquina, "IdTipoMaq", "MaquinaNombre", maquina.TipoMaquina.IdTipoMaq);
            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }
            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaquina,FechaCompra,PrecioCompra,VidaUtil,Disponible")] Maquina maquina)
        {
            if (id != maquina.IdMaquina)
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
                    if (!MaquinaExists(maquina.IdMaquina))
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
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .FirstOrDefaultAsync(m => m.IdMaquina == id);
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
            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina != null)
            {
                _context.Maquina.Remove(maquina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(int id)
        {
            return _context.Maquina.Any(e => e.IdMaquina == id);
        }
    }
}
