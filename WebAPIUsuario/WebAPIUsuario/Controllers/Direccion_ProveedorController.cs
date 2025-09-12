using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Direccion_ProveedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Direccion_ProveedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Direccion_Proveedor>>> ListarDireccion_Proveedor()
        {
            var direccion_proveedores = await _context.Direccion_Proveedores.ToListAsync();
            return Ok(direccion_proveedores);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Direccion>> GuardarDireccion_Proveedor(Direccion_Proveedor direccion_proveedor)
        {
            _context.Direccion_Proveedores.Add(direccion_proveedor);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, direccion_proveedor);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Direccion_Proveedor>> ActualizarDireccion_Proveedor(int id, Direccion_Proveedor direccion_proveedor)
        {
            var direccion_proveedorActualizado = await _context.Direccion_Proveedores.FindAsync(id);

            if (direccion_proveedorActualizado == null)
            {
                return NotFound();
            }

            direccion_proveedorActualizado.Calle = direccion_proveedor.Calle;
            direccion_proveedorActualizado.CodigoPostal = direccion_proveedor.CodigoPostal;
            direccion_proveedorActualizado.Ciudad = direccion_proveedor.Ciudad;
            direccion_proveedorActualizado.ProveedorId = direccion_proveedor.ProveedorId;

            await _context.SaveChangesAsync();

            return Ok(direccion_proveedorActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarDireccion_Proveedor(int id)
        {
            var direccion_proveedorActualizado = await _context.Direccion_Proveedores.FindAsync(id);

            if (direccion_proveedorActualizado == null)
            {
                return NotFound();
            }

            _context.Direccion_Proveedores.Remove(direccion_proveedorActualizado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
