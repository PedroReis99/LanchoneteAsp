using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lanchonete.Models;

namespace Lanchonete.Controllers
{
    public class CombosController : Controller
    {
        private readonly Context _context;

        public CombosController(Context context)
        {
            _context = context;
        }

        // GET: Comboes
        public async Task<IActionResult> Index()
        {
            var context = _context.Combos.Include(c => c.Acompanhamento).Include(c => c.Bebida).Include(c => c.Lanche);
            return View(await context.ToListAsync());
        }

        // GET: Comboes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combo = await _context.Combos
                .Include(c => c.Acompanhamento)
                .Include(c => c.Bebida)
                .Include(c => c.Lanche)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }

        // GET: Comboes/Create
        public IActionResult Create()
        {
            ViewData["AcompanhamentoId"] = new SelectList(_context.Acompanhamentos, "Id", "nome");
            ViewData["BebidaId"] = new SelectList(_context.Bebidas, "Id", "Nome");
            ViewData["LancheId"] = new SelectList(_context.Lanches, "Id", "Nome");
            return View();
        }

        // POST: Comboes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,LancheId,AcompanhamentoId,BebidaId,Preco")] Combo combo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcompanhamentoId"] = new SelectList(_context.Acompanhamentos, "Id", "nome", combo.AcompanhamentoId);
            ViewData["BebidaId"] = new SelectList(_context.Bebidas, "Id", "Nome", combo.BebidaId);
            ViewData["LancheId"] = new SelectList(_context.Lanches, "Id", "Nome", combo.LancheId);
            return View(combo);
        }

        // GET: Comboes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combo = await _context.Combos.FindAsync(id);
            if (combo == null)
            {
                return NotFound();
            }
            ViewData["AcompanhamentoId"] = new SelectList(_context.Acompanhamentos, "Id", "nome", combo.AcompanhamentoId);
            ViewData["BebidaId"] = new SelectList(_context.Bebidas, "Id", "Nome", combo.BebidaId);
            ViewData["LancheId"] = new SelectList(_context.Lanches, "Id", "Nome", combo.LancheId);
            return View(combo);
        }

        // POST: Comboes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,LancheId,AcompanhamentoId,BebidaId,Preco")] Combo combo)
        {
            if (id != combo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComboExists(combo.Id))
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
            ViewData["AcompanhamentoId"] = new SelectList(_context.Acompanhamentos, "Id", "nome", combo.AcompanhamentoId);
            ViewData["BebidaId"] = new SelectList(_context.Bebidas, "Id", "Nome", combo.BebidaId);
            ViewData["LancheId"] = new SelectList(_context.Lanches, "Id", "Nome", combo.LancheId);
            return View(combo);
        }

        // GET: Comboes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combo = await _context.Combos
                .Include(c => c.Acompanhamento)
                .Include(c => c.Bebida)
                .Include(c => c.Lanche)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }

        // POST: Comboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var combo = await _context.Combos.FindAsync(id);
            _context.Combos.Remove(combo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComboExists(int id)
        {
            return _context.Combos.Any(e => e.Id == id);
        }
    }
}
