using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIUsuario.Models;

public partial class DbUsuarioContext : DbContext
{
    public DbUsuarioContext()
    {
    }

    public DbUsuarioContext(DbContextOptions<DbUsuarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
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
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
