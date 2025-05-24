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
    public class CertificadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CertificadosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificado>>> GetCertificados()
        {
            return await _context.Certificados.Include(c => c.Inscripcion).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Certificado>> GetCertificado(int id)
        {
            var certificado = await _context.Certificados.Include(c => c.Inscripcion).FirstOrDefaultAsync(c => c.InscripcionId == id);
            if (certificado == null) return NotFound();
            return certificado;
        }

        [HttpPost]
        public async Task<ActionResult<Certificado>> PostCertificado(Certificado certificado)
        {
            _context.Certificados.Add(certificado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCertificado), new { id = certificado.InscripcionId }, certificado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificado(int id, Certificado certificado)
        {
            if (id != certificado.InscripcionId) return BadRequest();
            _context.Entry(certificado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificado(int id)
        {
            var certificado = await _context.Certificados.FindAsync(id);
            if (certificado == null) return NotFound();
            _context.Certificados.Remove(certificado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
