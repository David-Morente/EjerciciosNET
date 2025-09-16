using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Compra_ProveedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Compra_ProveedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Compra_Proveedor>>> ListarCompra_Proveedor()
        {
            var compra_proveedores = await _context.Compra_Proveedores.ToListAsync();
            return Ok(compra_proveedores);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Compra_Proveedor>> GuardarCompra_Proveedor(Compra_Proveedor compra_proveedor)
        {
            compra_proveedor.Fecha = DateTime.Now;
            _context.Compra_Proveedores.Add(compra_proveedor);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, compra_proveedor);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Compra_Proveedor>> ActualizarCompra_Proveedor(int id, Compra_Proveedor compra_proveedor)
        {
            var compra_proveedorActualizado = await _context.Compra_Proveedores.FindAsync(id);

            if (compra_proveedorActualizado == null)
            {
                return NotFound();
            }

            compra_proveedorActualizado.ProveedorId = compra_proveedor.ProveedorId;
            compra_proveedorActualizado.Total = compra_proveedor.Total;

            await _context.SaveChangesAsync();

            return Ok(compra_proveedorActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarCompra_Proveedor(int id)
        {
            var compra_proveedor = await _context.Compra_Proveedores.FindAsync(id);

            if (compra_proveedor == null)
            {
                return NotFound();
            }

            _context.Compra_Proveedores.Remove(compra_proveedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
