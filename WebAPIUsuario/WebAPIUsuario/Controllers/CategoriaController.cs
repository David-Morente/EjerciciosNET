using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Categoria>>> ListarCategoria()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return Ok(categorias);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Categoria>> GuardarCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, categoria);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Categoria>> ActualizarCategoria(int id, Categoria categoria)
        {
            var categoriaActualizado = await _context.Categorias.FindAsync(id);

            if (categoriaActualizado == null)
            {
                return NotFound();
            }

            categoriaActualizado.Nombre = categoria.Nombre;

            await _context.SaveChangesAsync();

            return Ok(categoriaActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
