namespace WebAPIUsuario.Models;

public  partial class Detalle_Factura
{
    public int Id { get; set; }

    public int FacturaId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }
}
