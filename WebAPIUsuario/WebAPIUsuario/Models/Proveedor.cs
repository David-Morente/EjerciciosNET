using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Proveedor")]
public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre_Empresa { get; set; } = null!;
}
