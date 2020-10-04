using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lanchonete.Models;

namespace LanchoneteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompanhamentosController : ControllerBase
    {
        private readonly Context _context;

        public AcompanhamentosController(Context context)
        {
            _context = context;
        }

        // GET: api/Acompanhamentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acompanhamento>>> GetAcompanhamentos()
        {
            return await _context.Acompanhamentos.ToListAsync();
        }

        // GET: api/Acompanhamentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acompanhamento>> GetAcompanhamento(int id)
        {
            var acompanhamento = await _context.Acompanhamentos.FindAsync(id);

            if (acompanhamento == null)
            {
                return NotFound();
            }

            return acompanhamento;
        }

        // PUT: api/Acompanhamentoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcompanhamento(int id, Acompanhamento acompanhamento)
        {
            if (id != acompanhamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(acompanhamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcompanhamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Acompanhamentoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Acompanhamento>> PostAcompanhamento(Acompanhamento acompanhamento)
        {
            _context.Acompanhamentos.Add(acompanhamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcompanhamento", new { id = acompanhamento.Id }, acompanhamento);
        }

        // DELETE: api/Acompanhamentoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Acompanhamento>> DeleteAcompanhamento(int id)
        {
            var acompanhamento = await _context.Acompanhamentos.FindAsync(id);
            if (acompanhamento == null)
            {
                return NotFound();
            }

            _context.Acompanhamentos.Remove(acompanhamento);
            await _context.SaveChangesAsync();

            return acompanhamento;
        }

        private bool AcompanhamentoExists(int id)
        {
            return _context.Acompanhamentos.Any(e => e.Id == id);
        }
    }
}
