using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Categoria")]
public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;
}

