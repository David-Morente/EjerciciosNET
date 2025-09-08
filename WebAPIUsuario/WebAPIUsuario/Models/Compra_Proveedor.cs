using System;
using System.Collections.Generic;

namespace WebAPIUsuario.Models;

public partial class Compra_Proveedor
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int ProveedorId { get; set; }

    public decimal Total { get; set; }
}
