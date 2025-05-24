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
    public class PonentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PonentesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ponente>>> GetPonentes()
        {
            return await _context.Ponentes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ponente>> GetPonente(int id)
        {
            var ponente = await _context.Ponentes.FindAsync(id);
            if (ponente == null) return NotFound();
            return ponente;
        }

        [HttpPost]
        public async Task<ActionResult<Ponente>> PostPonente(Ponente ponente)
        {
            _context.Ponentes.Add(ponente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPonente), new { id = ponente.Id }, ponente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonente(int id, Ponente ponente)
        {
            if (id != ponente.Id) return BadRequest();
            _context.Entry(ponente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonente(int id)
        {
            var ponente = await _context.Ponentes.FindAsync(id);
            if (ponente == null) return NotFound();
            _context.Ponentes.Remove(ponente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
