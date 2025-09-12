using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DireccionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Direccion>>> ListarDireccion()
        {
            var direcciones = await _context.Direcciones.ToListAsync();
            return Ok(direcciones);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Direccion>> GuardarDireccion(Direccion direccion)
        {
            _context.Direcciones.Add(direccion);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, direccion);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Direccion>> ActualizarDireccion(int id, Direccion direccion)
        {
            var direccionActualizado = await _context.Direcciones.FindAsync(id);

            if (direccionActualizado == null)
            {
                return NotFound();
            }

            direccionActualizado.Calle = direccion.Calle;
            direccionActualizado.CodigoPostal = direccion.CodigoPostal;
            direccionActualizado.Ciudad = direccion.Ciudad;
            direccionActualizado.ClienteId = direccion.ClienteId;

            await _context.SaveChangesAsync();

            return Ok(direccionActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarDireccion(int id)
        {
            var direccion = await _context.Direcciones.FindAsync(id);

            if (direccion == null)
            {
                return NotFound();
            }

            _context.Direcciones.Remove(direccion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
