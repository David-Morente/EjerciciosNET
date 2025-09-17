using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_FacturaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Detalle_FacturaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Detalle_Factura>>> ListarDetalle_Factura()
        {
            var detalle_facturas = await _context.Detalle_Facturas.ToListAsync();
            return Ok(detalle_facturas);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Detalle_Factura>> GuardarDetalle_Factura(Detalle_Factura detalle_factura)
        {
            _context.Detalle_Facturas.Add(detalle_factura);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, detalle_factura);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Detalle_Factura>> ActualizarDetalle_Factura(int id, Detalle_Factura detalle_factura)
        {
            var detalle_facturaActualizado = await _context.Detalle_Facturas.FindAsync(id);

            if (detalle_facturaActualizado == null)
            {
                return NotFound();
            }

            detalle_facturaActualizado.FacturaId = detalle_factura.FacturaId;
            detalle_facturaActualizado.ProductoId = detalle_factura.ProductoId;
            detalle_facturaActualizado.Cantidad = detalle_factura.Cantidad;

            await _context.SaveChangesAsync();

            return Ok(detalle_facturaActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarDetalle_Factura(int id)
        {
            var detalle_factura = await _context.Detalle_Facturas.FindAsync(id);

            if (detalle_factura == null)
            {
                return NotFound();
            }

            _context.Detalle_Facturas.Remove(detalle_factura);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
