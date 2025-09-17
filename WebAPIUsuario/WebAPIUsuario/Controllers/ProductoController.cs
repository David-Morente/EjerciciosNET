using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Producto>>> ListarProducto()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Producto>> GuardarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, producto);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Producto>> ActualizarProducto(int id, Producto producto)
        {
            var productoActualizado = await _context.Productos.FindAsync(id);

            if (productoActualizado == null)
            {
                return NotFound();
            }

            productoActualizado.Nombre = producto.Nombre;
            productoActualizado.Precio = producto.Precio;
            productoActualizado.Stock = producto.Stock;
            productoActualizado.CategoriaId = producto.CategoriaId;

            await _context.SaveChangesAsync();

            return Ok(productoActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
