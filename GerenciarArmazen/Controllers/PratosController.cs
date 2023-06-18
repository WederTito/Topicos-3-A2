﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciarArmazen.MeuContexto;
using GerenciarArmazen.Models;

namespace GerenciarArmazen.Controllers
{
    public class PratosController : Controller
    {
        private readonly Contexto _context;

        public PratosController(Contexto context)
        {
            _context = context;
        }

        // GET: Pratos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Prato.Include(p => p.Ingrediente);
            return View(await contexto.ToListAsync());
        }

        // GET: Pratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .Include(p => p.Ingrediente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // GET: Pratos/Create
        public IActionResult Create()
        {
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Id");
            return View();
        }

        // POST: Pratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IngredienteId")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Id", prato.IngredienteId);
            return View(prato);
        }

        // GET: Pratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato.FindAsync(id);
            if (prato == null)
            {
                return NotFound();
            }
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Id", prato.IngredienteId);
            return View(prato);
        }

        // POST: Pratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IngredienteId")] Prato prato)
        {
            if (id != prato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PratoExists(prato.Id))
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
            ViewData["IngredienteId"] = new SelectList(_context.Ingrediente, "Id", "Id", prato.IngredienteId);
            return View(prato);
        }

        // GET: Pratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prato == null)
            {
                return NotFound();
            }

            var prato = await _context.Prato
                .Include(p => p.Ingrediente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // POST: Pratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prato == null)
            {
                return Problem("Entity set 'Contexto.Prato'  is null.");
            }
            var prato = await _context.Prato.FindAsync(id);
            if (prato != null)
            {
                _context.Prato.Remove(prato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PratoExists(int id)
        {
          return (_context.Prato?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
