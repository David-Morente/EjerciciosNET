using System;
using System.Collections.Generic;

namespace WebAPIUsuario.Models;

public partial class Insumo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public int CategoriaInsumoId { get; set; }

    public int ProveedorId { get; set; }
}
