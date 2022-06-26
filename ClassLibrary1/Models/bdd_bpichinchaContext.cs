using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary1.Models
{
    public partial class bdd_bpichinchaContext : DbContext
    {
        public bdd_bpichinchaContext()
        {
        }

        public bdd_bpichinchaContext(DbContextOptions<bdd_bpichinchaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BpCliente> BpClientes { get; set; } = null!;
        public virtual DbSet<BpClienteCuenta> BpClienteCuenta { get; set; } = null!;
        public virtual DbSet<BpCuenta> BpCuenta { get; set; } = null!;
        public virtual DbSet<BpMovimiento> BpMovimientos { get; set; } = null!;
        public virtual DbSet<BpPersona> BpPersonas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=bdd_bpichincha;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BpCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__bp_clien__677F38F55941325F");

                entity.ToTable("bp_cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.ClaveCliente)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("clave_cliente");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.BpClientes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bp_client__estad__74AE54BC");
            });

            modelBuilder.Entity<BpClienteCuenta>(entity =>
            {
                entity.HasKey(e => e.IdClienteCuenta)
                    .HasName("PK__bp_clien__18B83731C8EB2A34");

                entity.ToTable("bp_cliente_cuenta");

                entity.Property(e => e.IdClienteCuenta).HasColumnName("id_cliente_cuenta");

                entity.Property(e => e.ClaveCliente)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("clave_cliente");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.BpClienteCuenta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bp_client__id_cl__797309D9");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.BpClienteCuenta)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bp_client__id_cu__7A672E12");
            });

            modelBuilder.Entity<BpCuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta)
                    .HasName("PK__bp_cuent__C7E28685307D5F24");

                entity.ToTable("bp_cuenta");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("numero_cuenta");

                entity.Property(e => e.SaldoInicial)
                    .HasColumnType("money")
                    .HasColumnName("saldo_inicial");

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("tipo_cuenta")
                    .IsFixedLength();
            });

            modelBuilder.Entity<BpMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento)
                    .HasName("PK__bp_movim__2A071C24F6E657EE");

                entity.ToTable("bp_movimiento");

                entity.Property(e => e.IdMovimiento).HasColumnName("id_movimiento");

                entity.Property(e => e.FechaMovimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_movimiento");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.SaldoCuenta)
                    .HasColumnType("money")
                    .HasColumnName("saldo_cuenta");

                entity.Property(e => e.TipoMovimiento)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("tipo_movimiento")
                    .IsFixedLength();

                entity.Property(e => e.ValorMovimiento)
                    .HasColumnType("money")
                    .HasColumnName("valor_movimiento");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.BpMovimientos)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bp_movimi__id_cu__7D439ABD");
            });

            modelBuilder.Entity<BpPersona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__bp_perso__228148B0F2DD0904");

                entity.ToTable("bp_persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.DireccionPersona)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion_persona");

                entity.Property(e => e.EdadPersona).HasColumnName("edad_persona");

                entity.Property(e => e.GeneroPersona)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("genero_persona")
                    .IsFixedLength();

                entity.Property(e => e.IdentificacionPersona)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("identificacion_persona");

                entity.Property(e => e.NombrePersona)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_persona");

                entity.Property(e => e.TelefonoPersona)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono_persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
