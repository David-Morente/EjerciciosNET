using System;
using System.Collections.Generic;

namespace WebAPIUsuario.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre_Empresa { get; set; } = null!;
}
