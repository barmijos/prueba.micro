using cliente.dominio.Entities.bp_cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cliente.persistencia.Configuration
{
    internal class MovimientoEntity : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder.HasKey(e => e.IdMovimiento)
                    .HasName("PK__bp_movim__2A071C24F6E657EE");

            builder.ToTable("bp_movimiento");

            builder.Property(e => e.IdMovimiento).HasColumnName("id_movimiento");

            builder.Property(e => e.FechaMovimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_movimiento");

            builder.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

            builder.Property(e => e.SaldoCuenta)
                .HasColumnType("money")
                .HasColumnName("saldo_cuenta");

            builder.Property(e => e.TipoMovimiento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("tipo_movimiento")
                .IsFixedLength();

            builder.Property(e => e.ValorMovimiento)
                .HasColumnType("money")
                .HasColumnName("valor_movimiento");

            builder.HasOne(d => d.IdCuentaNavigation)
                .WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bp_movimi__id_cu__7D439ABD");
        }
    }
}
