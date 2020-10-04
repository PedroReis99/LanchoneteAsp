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
    public class LanchesController : ControllerBase
    {
        private readonly Context _context;

        public LanchesController(Context context)
        {
            _context = context;
        }

        // GET: api/Lanches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lanche>>> GetLanches()
        {
            return await _context.Lanches.ToListAsync();
        }

        // GET: api/Lanches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lanche>> GetLanche(int id)
        {
            var lanche = await _context.Lanches.FindAsync(id);

            if (lanche == null)
            {
                return NotFound();
            }

            return lanche;
        }

        // PUT: api/Lanches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanche(int id, Lanche lanche)
        {
            if (id != lanche.Id)
            {
                return BadRequest();
            }

            _context.Entry(lanche).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancheExists(id))
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

        // POST: api/Lanches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lanche>> PostLanche(Lanche lanche)
        {
            _context.Lanches.Add(lanche);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanche", new { id = lanche.Id }, lanche);
        }

        // DELETE: api/Lanches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lanche>> DeleteLanche(int id)
        {
            var lanche = await _context.Lanches.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }

            _context.Lanches.Remove(lanche);
            await _context.SaveChangesAsync();

            return lanche;
        }

        private bool LancheExists(int id)
        {
            return _context.Lanches.Any(e => e.Id == id);
        }
    }
}
