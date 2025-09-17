using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIUsuario.Models;

[Table("Producto")]
public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    [Column("categoria_id")]
    public int CategoriaId { get; set; }
}
