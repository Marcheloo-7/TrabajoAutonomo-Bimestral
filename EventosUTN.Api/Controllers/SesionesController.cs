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
    public class SesionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SesionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sesion>>> GetSesiones()
        {
            return await _context.Sesiones.Include(s => s.Evento).Include(s => s.Sala).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sesion>> GetSesion(int id)
        {
            var sesion = await _context.Sesiones.Include(s => s.Evento).Include(s => s.Sala).FirstOrDefaultAsync(s => s.Id == id);
            if (sesion == null) return NotFound();
            return sesion;
        }

        [HttpPost]
        public async Task<ActionResult<Sesion>> PostSesion(Sesion sesion)
        {
            _context.Sesiones.Add(sesion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSesion), new { id = sesion.Id }, sesion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSesion(int id, Sesion sesion)
        {
            if (id != sesion.Id) return BadRequest();
            _context.Entry(sesion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            var sesion = await _context.Sesiones.FindAsync(id);
            if (sesion == null) return NotFound();
            _context.Sesiones.Remove(sesion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
