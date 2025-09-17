using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_CompraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Detalle_CompraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Detalle_Compra>>> ListarDetalle_Compra()
        {
            var detalle_compras = await _context.Detalle_Compras.ToListAsync();
            return Ok(detalle_compras);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Detalle_Compra>> GuardarDetalle_Compra(Detalle_Compra detalle_compra)
        {
            _context.Detalle_Compras.Add(detalle_compra);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, detalle_compra);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Detalle_Compra>> ActualizarDetalle_Compra(int id, Detalle_Compra detalle_compra)
        {
            var detalle_compraActualizado = await _context.Detalle_Compras.FindAsync(id);

            if (detalle_compraActualizado == null)
            {
                return NotFound();
            }

            detalle_compraActualizado.CompraProveedorId = detalle_compra.CompraProveedorId;
            detalle_compraActualizado.InsumoId = detalle_compra.InsumoId;
            detalle_compraActualizado.Cantidad = detalle_compra.Cantidad;
            detalle_compraActualizado.PrecioUnitario = detalle_compra.PrecioUnitario;

            await _context.SaveChangesAsync();

            return Ok(detalle_compraActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarDetalle_Compra(int id)
        {
            var detalle_compra = await _context.Detalle_Compras.FindAsync(id);

            if (detalle_compra == null)
            {
                return NotFound();
            }

            _context.Detalle_Compras.Remove(detalle_compra);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
