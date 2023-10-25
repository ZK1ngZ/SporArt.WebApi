using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SporArt.Data;
using SporArt.Models.DTOs;
using SpotClass;

namespace SporArt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Itens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItens()
        {
          if (_context.Itens == null)
          {
              return NotFound();
          }
          



            return await _context.Itens.ToListAsync();

        }
        [HttpGet("porcategoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ItemDTO>>>GetItemPorCategoria(int categoriaId)
        {
            var listaItens = await _context.Itens.Include(i => i.Categoria).Where(i => i.Categoria.Id == categoriaId).ToListAsync();
            var listaItensDto = new List<ItemDTO>();

            foreach (var item in listaItens)
            {
                var itemDTO = new ItemDTO
                {
                    Id = item.Id,
                    Cor = item.Cor,
                    Formato = item.Formato,
                    NomeCategoria = item.Categoria.Nome
                };
                listaItensDto.Add(itemDTO);
            }

            return listaItensDto;



        }





        // GET: api/Itens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItem(int id)
        {




          if (_context.Itens == null)
          {
              return NotFound();
          }
            var item = await _context.Itens.Include(i => i.Categoria).FirstOrDefaultAsync(i => i.Id == id);
            ItemDTO itemDTO = new ItemDTO
            {
                Id = item.Id,
                Cor = item.Cor,
                Formato = item.Formato,
                NomeCategoria = item.Categoria.Nome

            };

           




            if (item == null)
            {
                return NotFound();
            }

            return itemDTO;
        }

        // PUT: api/Itens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Itens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
          if (_context.Itens == null)
          {
              return Problem("Entity set 'AppDbContext.Itens'  is null.");
          }
            _context.Itens.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Itens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (_context.Itens == null)
            {
                return NotFound();
            }
            var item = await _context.Itens.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return (_context.Itens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
