using System;
using System.Collections.Generic;

namespace WebAPIUsuario.Models;

public partial class Tienda
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;
}
