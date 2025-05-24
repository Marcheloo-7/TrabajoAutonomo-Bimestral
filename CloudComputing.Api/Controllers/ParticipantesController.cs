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
    public class ParticipantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participante>>> GetParticipantes()
        {
            return await _context.Participantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participante>> GetParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null) return NotFound();
            return participante;
        }

        [HttpPost]
        public async Task<ActionResult<Participante>> PostParticipante(Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParticipante), new { id = participante.Id }, participante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipante(int id, Participante participante)
        {
            if (id != participante.Id) return BadRequest();
            _context.Entry(participante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null) return NotFound();
            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
