using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Usuario")]
public partial class Usuario
{
    public int Id { get; set; }

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    [Column("cliente_id")]
    public int ClienteId { get; set; }
}
