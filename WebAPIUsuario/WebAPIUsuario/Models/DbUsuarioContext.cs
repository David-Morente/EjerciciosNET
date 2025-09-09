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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F0E238A8D");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
