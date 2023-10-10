using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SporArt.Data;
using SporArt.Models;

namespace SporArt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinturasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PinturasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pinturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pintura>>> GetPinturas()
        {
          if (_context.Pinturas == null)
          {
              return NotFound();
          }
            return await _context.Pinturas.ToListAsync();
        }

        // GET: api/Pinturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pintura>> GetPintura(int id)
        {
          if (_context.Pinturas == null)
          {
              return NotFound();
          }
            var pintura = await _context.Pinturas.FindAsync(id);

            if (pintura == null)
            {
                return NotFound();
            }

            return pintura;
        }

        // PUT: api/Pinturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPintura(int id, Pintura pintura)
        {
            if (id != pintura.Id)
            {
                return BadRequest();
            }

            _context.Entry(pintura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PinturaExists(id))
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

        // POST: api/Pinturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pintura>> PostPintura(Pintura pintura)
        {
          if (_context.Pinturas == null)
          {
              return Problem("Entity set 'AppDbContext.Pinturas'  is null.");
          }
            _context.Pinturas.Add(pintura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPintura", new { id = pintura.Id }, pintura);
        }

        // DELETE: api/Pinturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePintura(int id)
        {
            if (_context.Pinturas == null)
            {
                return NotFound();
            }
            var pintura = await _context.Pinturas.FindAsync(id);
            if (pintura == null)
            {
                return NotFound();
            }

            _context.Pinturas.Remove(pintura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PinturaExists(int id)
        {
            return (_context.Pinturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
