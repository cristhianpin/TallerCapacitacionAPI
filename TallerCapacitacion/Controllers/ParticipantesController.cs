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
    public class ParticipantesController : ControllerBase
    {
        private readonly TallerCapacitacionContext _context;

        public ParticipantesController(TallerCapacitacionContext context)
        {
            _context = context;
        }

        // GET: api/Participantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participante>>> GetParticipantes()
        {
          if (_context.Participantes == null)
          {
              return NotFound();
          }
            return await _context.Participantes.ToListAsync();
        }

        // GET: api/Participantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participante>> GetParticipante(int id)
        {
          if (_context.Participantes == null)
          {
              return NotFound();
          }
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null)
            {
                return NotFound();
            }

            return participante;
        }

        // PUT: api/Participantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipante(int id, Participante participante)
        {
            if (id != participante.IdParticipante)
            {
                return BadRequest();
            }

            _context.Entry(participante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteExists(id))
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

        // POST: api/Participantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participante>> PostParticipante(Participante participante)
        {
          if (_context.Participantes == null)
          {
              return Problem("Entity set 'TallerCapacitacionContext.Participantes'  is null.");
          }
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipante", new { id = participante.IdParticipante }, participante);
        }

        // DELETE: api/Participantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            if (_context.Participantes == null)
            {
                return NotFound();
            }
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }

            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipanteExists(int id)
        {
            return (_context.Participantes?.Any(e => e.IdParticipante == id)).GetValueOrDefault();
        }
    }
}
