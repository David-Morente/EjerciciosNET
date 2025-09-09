using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

namespace WebAPIUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpPost("guardar")]
        public async Task<ActionResult<Cliente>> GuardarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, cliente);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<Cliente>> ActualizarCliente(int id, Cliente cliente)
        {
            var clienteActualizado = await _context.Clientes.FindAsync(id);

            if (clienteActualizado == null)
            {
                return NotFound();
            }

            clienteActualizado.Nombre = cliente.Nombre;
            clienteActualizado.Apellido = cliente.Apellido;

            await _context.SaveChangesAsync();

            return Ok(clienteActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
