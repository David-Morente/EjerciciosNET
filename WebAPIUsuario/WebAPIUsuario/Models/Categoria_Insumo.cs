using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Categoria_Insumo")]
public partial class Categoria_Insumo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}
