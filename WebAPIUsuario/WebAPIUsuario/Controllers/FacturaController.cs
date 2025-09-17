using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacturaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Factura>>> ListarFactura()
        {
            var facturas = await _context.Facturas.ToListAsync();
            return Ok(facturas);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Factura>> GuardarFactura(Factura factura)
        {
            factura.Fecha = DateTime.Now;
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, factura);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Factura>> ActualizarFactura(int id, Factura factura)
        {
            var facturaActualizado = await _context.Facturas.FindAsync(id);

            if (facturaActualizado == null)
            {
                return NotFound();
            }

            facturaActualizado.Total = factura.Total;
            facturaActualizado.ClienteId = factura.ClienteId;
            facturaActualizado.TiendaId = factura.TiendaId;

            await _context.SaveChangesAsync();

            return Ok(facturaActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarFactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
