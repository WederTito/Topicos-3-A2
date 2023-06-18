using System;
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
    public class Ingredientes1Controller : Controller
    {
        private readonly Contexto _context;

        public Ingredientes1Controller(Contexto context)
        {
            _context = context;
        }

        // GET: Ingredientes1
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Ingrediente.Include(i => i.Armazenamento).Include(i => i.Categoria);
            return View(await contexto.ToListAsync());
        }

        // GET: Ingredientes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ingrediente == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingrediente
                .Include(i => i.Armazenamento)
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // GET: Ingredientes1/Create
        public IActionResult Create()
        {
            ViewData["ArmazenamentoId"] = new SelectList(_context.Armazenamento, "Id", "Id");
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Id");
            return View();
        }

        // POST: Ingredientes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Validade,CategoriaId,ArmazenamentoId")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingrediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmazenamentoId"] = new SelectList(_context.Armazenamento, "Id", "Id", ingrediente.ArmazenamentoId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Id", ingrediente.CategoriaId);
            return View(ingrediente);
        }

        // GET: Ingredientes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingrediente == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingrediente.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            ViewData["ArmazenamentoId"] = new SelectList(_context.Armazenamento, "Id", "Id", ingrediente.ArmazenamentoId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Id", ingrediente.CategoriaId);
            return View(ingrediente);
        }

        // POST: Ingredientes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Validade,CategoriaId,ArmazenamentoId")] Ingrediente ingrediente)
        {
            if (id != ingrediente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingrediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredienteExists(ingrediente.Id))
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
            ViewData["ArmazenamentoId"] = new SelectList(_context.Armazenamento, "Id", "Id", ingrediente.ArmazenamentoId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Id", ingrediente.CategoriaId);
            return View(ingrediente);
        }

        // GET: Ingredientes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingrediente == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingrediente
                .Include(i => i.Armazenamento)
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // POST: Ingredientes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingrediente == null)
            {
                return Problem("Entity set 'Contexto.Ingrediente'  is null.");
            }
            var ingrediente = await _context.Ingrediente.FindAsync(id);
            if (ingrediente != null)
            {
                _context.Ingrediente.Remove(ingrediente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredienteExists(int id)
        {
          return (_context.Ingrediente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
