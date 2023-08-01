using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerCapacitacion.Data;
using TallerCapacitacion.Models;

namespace TallerCapacitacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalleresController : ControllerBase
    {
        private readonly TallerCapacitacionContext _context;

        public TalleresController(TallerCapacitacionContext context)
        {
            _context = context;
        }

        // GET: api/Talleres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tallere>>> GetTalleres()
        {
          if (_context.Talleres == null)
          {
              return NotFound();
          }
            return await _context.Talleres.ToListAsync();
        }

        // GET: api/Talleres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tallere>> GetTallere(int id)
        {
          if (_context.Talleres == null)
          {
              return NotFound();
          }
            var tallere = await _context.Talleres.FindAsync(id);

            if (tallere == null)
            {
                return NotFound();
            }

            return tallere;
        }

        // PUT: api/Talleres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTallere(int id, Tallere tallere)
        {
            if (id != tallere.IdTaller)
            {
                return BadRequest();
            }

            _context.Entry(tallere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TallereExists(id))
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

        // POST: api/Talleres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tallere>> PostTallere(Tallere tallere)
        {
          if (_context.Talleres == null)
          {
              return Problem("Entity set 'TallerCapacitacionContext.Talleres'  is null.");
          }
            _context.Talleres.Add(tallere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTallere", new { id = tallere.IdTaller }, tallere);
        }

        // DELETE: api/Talleres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTallere(int id)
        {
            if (_context.Talleres == null)
            {
                return NotFound();
            }
            var tallere = await _context.Talleres.FindAsync(id);
            if (tallere == null)
            {
                return NotFound();
            }

            _context.Talleres.Remove(tallere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TallereExists(int id)
        {
            return (_context.Talleres?.Any(e => e.IdTaller == id)).GetValueOrDefault();
        }
    }
}
