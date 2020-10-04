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
    public class BebidasController : ControllerBase
    {
        private readonly Context _context;

        public BebidasController(Context context)
        {
            _context = context;
        }

        // GET: api/Bebidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bebida>>> GetBebidas()
        {
            return await _context.Bebidas.ToListAsync();
        }

        // GET: api/Bebidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bebida>> GetBebida(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);

            if (bebida == null)
            {
                return NotFound();
            }

            return bebida;
        }

        // PUT: api/Bebidas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBebida(int id, Bebida bebida)
        {
            if (id != bebida.Id)
            {
                return BadRequest();
            }

            _context.Entry(bebida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BebidaExists(id))
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

        // POST: api/Bebidas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bebida>> PostBebida(Bebida bebida)
        {
            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBebida", new { id = bebida.Id }, bebida);
        }

        // DELETE: api/Bebidas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bebida>> DeleteBebida(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }

            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();

            return bebida;
        }

        private bool BebidaExists(int id)
        {
            return _context.Bebidas.Any(e => e.Id == id);
        }
    }
}
