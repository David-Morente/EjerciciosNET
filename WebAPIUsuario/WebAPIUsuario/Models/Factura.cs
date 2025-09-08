namespace WebAPIUsuario.Models;

public class Factura
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public int TiendaId { get; set; }
}
