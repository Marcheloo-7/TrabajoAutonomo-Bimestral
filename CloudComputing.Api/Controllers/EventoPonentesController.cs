using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventosUTN.Models;

namespace EventosUTN.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoPonentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventoPonentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventoPonentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoPonente>>> GetEventoPonentes()
        {
            return await _context.EventoPonentes
                .Include(ep => ep.Evento)
                .Include(ep => ep.Ponente)
                .ToListAsync();
        }

        // POST: api/EventoPonentes
        [HttpPost]
        public async Task<ActionResult<EventoPonente>> PostEventoPonente(EventoPonente eventoPonente)
        {
            // Verifica que no exista la relación
            var exists = await _context.EventoPonentes
                .AnyAsync(ep => ep.EventoId == eventoPonente.EventoId && ep.PonenteId == eventoPonente.PonenteId);
            if (exists)
                return Conflict("La relación Evento-Ponente ya existe.");

            _context.EventoPonentes.Add(eventoPonente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventoPonentes), new { eventoId = eventoPonente.EventoId, ponenteId = eventoPonente.PonenteId }, eventoPonente);
        }

        // DELETE: api/EventoPonentes?eventoId=1&ponenteId=2
        [HttpDelete]
        public async Task<IActionResult> DeleteEventoPonente([FromQuery] int eventoId, [FromQuery] int ponenteId)
        {
            var eventoPonente = await _context.EventoPonentes.FindAsync(eventoId, ponenteId);
            if (eventoPonente == null)
                return NotFound();

            _context.EventoPonentes.Remove(eventoPonente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

