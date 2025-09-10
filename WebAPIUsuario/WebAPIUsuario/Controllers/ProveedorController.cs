using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProveedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Proveedor>>> ListarProveedor()
        {
            var proveedores = await _context.Proveedores.ToListAsync();
            return Ok(proveedores);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Proveedor>> GuardarProovedor(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, proveedor);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Proveedor>> ActualizarCliente(int id, Proveedor proveedor)
        {
            var proveedorActualizado = await _context.Proveedores.FindAsync(id);

            if (proveedorActualizado == null)
            {
                return NotFound();
            }

            proveedorActualizado.Nombre_Empresa = proveedor.Nombre_Empresa;

            await _context.SaveChangesAsync();

            return Ok(proveedorActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarProveedor(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
