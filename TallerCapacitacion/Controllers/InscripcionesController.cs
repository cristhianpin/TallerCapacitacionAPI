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
    public class InscripcionesController : ControllerBase
    {
        private readonly TallerCapacitacionContext _context;

        public InscripcionesController(TallerCapacitacionContext context)
        {
            _context = context;
        }

        // GET: api/Inscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripcione>>> GetInscripciones()
        {
          if (_context.Inscripciones == null)
          {
              return NotFound();
          }
            return await _context.Inscripciones.ToListAsync();
        }

        // GET: api/Inscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripcione>> GetInscripcione(int id)
        {
          if (_context.Inscripciones == null)
          {
              return NotFound();
          }
            var inscripcione = await _context.Inscripciones.FindAsync(id);

            if (inscripcione == null)
            {
                return NotFound();
            }

            return inscripcione;
        }

        // PUT: api/Inscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcione(int id, Inscripcione inscripcione)
        {
            if (id != inscripcione.IdInscripcion)
            {
                return BadRequest();
            }

            _context.Entry(inscripcione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcioneExists(id))
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

        // POST: api/Inscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inscripcione>> PostInscripcione(Inscripcione inscripcione)
        {
          if (_context.Inscripciones == null)
          {
              return Problem("Entity set 'TallerCapacitacionContext.Inscripciones'  is null.");
          }
            _context.Inscripciones.Add(inscripcione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscripcione", new { id = inscripcione.IdInscripcion }, inscripcione);
        }

        // DELETE: api/Inscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcione(int id)
        {
            if (_context.Inscripciones == null)
            {
                return NotFound();
            }
            var inscripcione = await _context.Inscripciones.FindAsync(id);
            if (inscripcione == null)
            {
                return NotFound();
            }

            _context.Inscripciones.Remove(inscripcione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscripcioneExists(int id)
        {
            return (_context.Inscripciones?.Any(e => e.IdInscripcion == id)).GetValueOrDefault();
        }
    }
}
