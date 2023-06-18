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
    public class ArmazenamentoesController : Controller
    {
        private readonly Contexto _context;

        public ArmazenamentoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Armazenamentoes
        public async Task<IActionResult> Index()
        {
              return _context.Armazenamento != null ? 
                          View(await _context.Armazenamento.ToListAsync()) :
                          Problem("Entity set 'Contexto.Armazenamento'  is null.");
        }

        // GET: Armazenamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Armazenamento == null)
            {
                return NotFound();
            }

            var armazenamento = await _context.Armazenamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (armazenamento == null)
            {
                return NotFound();
            }

            return View(armazenamento);
        }

        // GET: Armazenamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Armazenamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Armazenamento armazenamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armazenamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(armazenamento);
        }

        // GET: Armazenamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Armazenamento == null)
            {
                return NotFound();
            }

            var armazenamento = await _context.Armazenamento.FindAsync(id);
            if (armazenamento == null)
            {
                return NotFound();
            }
            return View(armazenamento);
        }

        // POST: Armazenamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Armazenamento armazenamento)
        {
            if (id != armazenamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armazenamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmazenamentoExists(armazenamento.Id))
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
            return View(armazenamento);
        }

        // GET: Armazenamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Armazenamento == null)
            {
                return NotFound();
            }

            var armazenamento = await _context.Armazenamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (armazenamento == null)
            {
                return NotFound();
            }

            return View(armazenamento);
        }

        // POST: Armazenamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Armazenamento == null)
            {
                return Problem("Entity set 'Contexto.Armazenamento'  is null.");
            }
            var armazenamento = await _context.Armazenamento.FindAsync(id);
            if (armazenamento != null)
            {
                _context.Armazenamento.Remove(armazenamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmazenamentoExists(int id)
        {
          return (_context.Armazenamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
