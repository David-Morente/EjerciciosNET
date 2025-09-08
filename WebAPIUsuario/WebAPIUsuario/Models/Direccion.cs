using System;
using System.Collections.Generic;

namespace WebAPIUsuario.Models;

public partial class Direccion
{
    int ID { get; set; }

    string Calle { get; set; }

    int CodigoPostal { get; set; }

    string Ciudad { get; set; }

    int ClienteId { get; set; }
}
