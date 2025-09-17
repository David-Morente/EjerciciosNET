using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Detalle_Factura")]
public  partial class Detalle_Factura
{
    public int Id { get; set; }

    [Column("factura_id")]
    public int FacturaId { get; set; }

    [Column("producto_id")]
    public int ProductoId { get; set; }

    public int Cantidad { get; set; }
}
