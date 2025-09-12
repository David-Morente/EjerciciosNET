using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Direccion")]
public partial class Direccion
{
    public int ID { get; set; }

    public string Calle { get; set; }

    [Column("codigo_postal")]
    public int CodigoPostal { get; set; }

    public string Ciudad { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }
}
