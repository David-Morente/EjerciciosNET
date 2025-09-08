using System;
using System.Collections.Generic;

namespace WebAPIUsuario.Models;

public partial class Direccion_Proveedor
{ 
    public int Id { get; set; }
    public string Calle { get; set; } = null!;
    public int CodigoPostal { get; set; }
    public string Ciudad { get; set; } = null!;
    public int ProveedorId { get; set; }
}
