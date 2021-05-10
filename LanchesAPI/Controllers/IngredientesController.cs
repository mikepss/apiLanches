using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanchesAPI.Data;
using LanchesAPI.Models;

namespace LanchesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ingredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
            return await _context.Ingredientes.ToListAsync();
        }

        // GET: api/Ingredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return ingrediente;
        }

        // PUT: api/Ingredientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngrediente(int id, Ingrediente ingrediente)
        {
            if (id != ingrediente.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredienteExists(id))
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

        // POST: api/Ingredientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingrediente>> PostIngrediente(Ingrediente ingrediente)
        {
            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngrediente", new { id = ingrediente.Id }, ingrediente);
        }

        // DELETE: api/Ingredientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngrediente(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredienteExists(int id)
        {
            return _context.Ingredientes.Any(e => e.Id == id);
        }
    }
}
