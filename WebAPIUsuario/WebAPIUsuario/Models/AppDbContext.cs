using Microsoft.EntityFrameworkCore;

namespace WebAPIUsuario.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Direccion> Direcciones { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Direccion_Proveedor> Direccion_Proveedores { get; set; }
        public virtual DbSet<Categoria_Insumo> Categoria_Insumos { get; set; }
        public virtual DbSet<Insumo> Insumos { get; set; }
        public virtual DbSet<Compra_Proveedor> Compra_Proveedores { get; set; }
        public virtual DbSet<Detalle_Compra> Detalle_Compras { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Tienda> Tiendas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Detalle_Factura> Detalle_Facturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=Store;Uid=root;Pwd=12345;Port=3306",
                    new MySqlServerVersion(new Version(8,0,23)));
            }
        }
    }
}
