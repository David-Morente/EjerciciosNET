using System;
using System.Collections.Generic;

namespace WebAPIUsuario.Models;

public partial class Detalle_Compra
{
    public int Id { get; set; }

    public int CompraProveedorId { get; set; }

    public int InsumoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }
}
