using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanchesAPI.Data;

namespace LanchesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdicionaisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdicionaisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Adicionais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adicional>>> Getadicionais()
        {
            return await _context.adicionais.ToListAsync();
        }

        // GET: api/Adicionais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adicional>> GetAdicional(int id)
        {
            var adicional = await _context.adicionais.FindAsync(id);

            if (adicional == null)
            {
                return NotFound();
            }

            return adicional;
        }

        // PUT: api/Adicionais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdicional(int id, Adicional adicional)
        {
            if (id != adicional.id)
            {
                return BadRequest();
            }

            _context.Entry(adicional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdicionalExists(id))
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

        // POST: api/Adicionais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adicional>> PostAdicional(Adicional adicional)
        {
            _context.adicionais.Add(adicional);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdicional", new { id = adicional.id }, adicional);
        }

        // DELETE: api/Adicionais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdicional(int id)
        {
            var adicional = await _context.adicionais.FindAsync(id);
            if (adicional == null)
            {
                return NotFound();
            }

            _context.adicionais.Remove(adicional);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdicionalExists(int id)
        {
            return _context.adicionais.Any(e => e.id == id);
        }
    }
}
