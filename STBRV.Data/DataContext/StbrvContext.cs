using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using STBRV.Entities;

namespace STBRV.Data.DataContext
{
    public partial class StbrvContext : DbContext
    {
        public StbrvContext()
        {
        }

        public StbrvContext(DbContextOptions<StbrvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<ArticuloTiendum> ArticuloTienda { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; } = null!;
        public virtual DbSet<Tiendum> Tienda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //    optionsBuilder.UseSqlServer("Server=.;Database=Stbrv;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("articulos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(19, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<ArticuloTiendum>(entity =>
            {
                entity.ToTable("articulo_tienda");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");

                entity.Property(e => e.IdTienda).HasColumnName("idTienda");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.ArticuloTienda)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("fk_tiendaArticulo_tienda");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.ArticuloTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("fk_tiendaArticulo_articulo");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ClienteArticulo>(entity =>
            {
                entity.ToTable("cliente_articulo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.ClienteArticulos)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("fk_clienteArticulo_articulo");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClienteArticulos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_clienteArticulo_cliente");
            });

            modelBuilder.Entity<Tiendum>(entity =>
            {
                entity.ToTable("tienda");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sucursal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
