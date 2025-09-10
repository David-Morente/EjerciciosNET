using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categoria_InsumoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Categoria_InsumoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Categoria_Insumo>>> ListarCategoria_Insumo()
        {
            var categorias_insumos = await _context.Categoria_Insumos.ToListAsync();
            return Ok(categorias_insumos);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Categoria>> GuardarCategoria_Insumo(Categoria_Insumo categoria_insumo)
        {
            _context.Categoria_Insumos.Add(categoria_insumo);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, categoria_insumo);
        } 

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Categoria>> ActualizarCliente(int id, Categoria_Insumo categoria_insumo)
        {
            var categoria_insumoActualizado = await _context.Categoria_Insumos.FindAsync(id);

            if (categoria_insumoActualizado == null)
            {
                return NotFound();
            }

            categoria_insumoActualizado.Nombre = categoria_insumo.Nombre;

            await _context.SaveChangesAsync();

            return Ok(categoria_insumoActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarCategoria_Insumo(int id)
        {
            var categoria_insumo = await _context.Categoria_Insumos.FindAsync(id);

            if (categoria_insumo == null)
            {
                return NotFound();
            }

            _context.Categoria_Insumos.Remove(categoria_insumo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
