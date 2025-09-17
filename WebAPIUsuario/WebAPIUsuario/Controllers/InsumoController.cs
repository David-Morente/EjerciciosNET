using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsumoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Insumo>>> ListarInsumo()
        {
            var insumos = await _context.Insumos.ToListAsync();
            return Ok(insumos);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Insumo>> GuardarInsumo(Insumo insumo)
        {
            _context.Insumos.Add(insumo);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, insumo);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Insumo>> ActualizarInsumo(int id, Insumo insumo)
        {
            var insumoActualizado = await _context.Insumos.FindAsync(id);

            if (insumoActualizado == null)
            {
                return NotFound();
            }

            insumoActualizado.Nombre = insumo.Nombre;
            insumoActualizado.Cantidad = insumo.Cantidad;
            insumoActualizado.Precio = insumo.Precio;
            insumoActualizado.CategoriaInsumoId = insumo.CategoriaInsumoId;
            insumoActualizado.ProveedorId = insumo.ProveedorId;

            await _context.SaveChangesAsync();

            return Ok(insumoActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarInsumo(int id)
        {
            var insumo = await _context.Insumos.FindAsync(id);

            if (insumo == null)
            {
                return NotFound();
            }

            _context.Insumos.Remove(insumo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
