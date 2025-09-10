using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Tienda>>> ListarTienda()
        {
            var tiendas = await _context.Tiendas.ToListAsync();
            return Ok(tiendas);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Tienda>> GuardarTienda(Tienda tienda)
        {
            _context.Tiendas.Add(tienda);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, tienda);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Tienda>> ActualizarTienda(int id, Tienda tienda)
        {
            var tiendaActualizado = await _context.Tiendas.FindAsync(id);

            if (tiendaActualizado == null)
            {
                return NotFound();
            }

            tiendaActualizado.Nombre = tiendaActualizado.Nombre;
            tiendaActualizado.Direccion = tiendaActualizado.Direccion;

            await _context.SaveChangesAsync();

            return Ok(tiendaActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarTienda(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);

            if (tienda == null)
            {
                return NotFound();
            }

            _context.Tiendas.Remove(tienda);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
