using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Insumo")]
public partial class Insumo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;

    [Column("stock")]
    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    [Column("categoriaInsumo_id")]
    public int CategoriaInsumoId { get; set; }

    [Column("proveedor_id")]
    public int ProveedorId { get; set; }
}
