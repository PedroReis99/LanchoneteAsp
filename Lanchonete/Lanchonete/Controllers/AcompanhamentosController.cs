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
    public class AcompanhamentosController : Controller
    {
        private readonly Context _context;

        public AcompanhamentosController(Context context)
        {
            _context = context;
        }

        // GET: Acompanhamentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acompanhamentos.ToListAsync());
        }

        // GET: Acompanhamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.Acompanhamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            return View(acompanhamento);
        }

        // GET: Acompanhamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acompanhamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome")] Acompanhamento acompanhamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acompanhamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acompanhamento);
        }

        // GET: Acompanhamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.Acompanhamentos.FindAsync(id);
            if (acompanhamento == null)
            {
                return NotFound();
            }
            return View(acompanhamento);
        }

        // POST: Acompanhamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome")] Acompanhamento acompanhamento)
        {
            if (id != acompanhamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acompanhamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcompanhamentoExists(acompanhamento.Id))
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
            return View(acompanhamento);
        }

        // GET: Acompanhamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acompanhamento = await _context.Acompanhamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            return View(acompanhamento);
        }

        // POST: Acompanhamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acompanhamento = await _context.Acompanhamentos.FindAsync(id);
            _context.Acompanhamentos.Remove(acompanhamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcompanhamentoExists(int id)
        {
            return _context.Acompanhamentos.Any(e => e.Id == id);
        }
    }
}
