using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Direccion_Proveedor")]
public partial class Direccion_Proveedor
{ 
    public int Id { get; set; }
    public string Calle { get; set; } = null!;

    [Column("codigo_postal")]
    public int CodigoPostal { get; set; }
    public string Ciudad { get; set; } = null!;

    [Column("proveedor_id")]
    public int ProveedorId { get; set; }
}
