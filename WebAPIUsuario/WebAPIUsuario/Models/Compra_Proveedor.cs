using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Compra_Proveedor")]
public partial class Compra_Proveedor
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    [Column("proveedor_id")]
    public int ProveedorId { get; set; }

    public decimal Total { get; set; }
}
