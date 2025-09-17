using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Factura")]
public partial class Factura
{
    public int Id { get; set; }

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [Column("tienda_id")]
    public int TiendaId { get; set; }
}
