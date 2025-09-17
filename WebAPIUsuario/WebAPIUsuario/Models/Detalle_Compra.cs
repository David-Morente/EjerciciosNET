using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Detalle_Compra")]
public partial class Detalle_Compra
{
    public int Id { get; set; }

    [Column("compra_id")]
    public int CompraProveedorId { get; set; }

    [Column("insumo_id")]
    public int InsumoId { get; set; }

    public int Cantidad { get; set; }

    [Column("precio_unitario")]
    public decimal PrecioUnitario { get; set; }
}
