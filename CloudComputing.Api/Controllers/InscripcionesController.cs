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
    public class InscripcionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InscripcionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> GetInscripciones()
        {
            return await _context.Inscripciones
                .Include(i => i.Evento)
                .Include(i => i.Participante)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripcion>> GetInscripcion(int id)
        {
            var inscripcion = await _context.Inscripciones
                .Include(i => i.Evento)
                .Include(i => i.Participante)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (inscripcion == null) return NotFound();
            return inscripcion;
        }

        [HttpPost]
        public async Task<ActionResult<Inscripcion>> PostInscripcion(Inscripcion inscripcion)
        {
            _context.Inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInscripcion), new { id = inscripcion.Id }, inscripcion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcion(int id, Inscripcion inscripcion)
        {
            if (id != inscripcion.Id) return BadRequest();
            _context.Entry(inscripcion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcion(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion == null) return NotFound();
            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
