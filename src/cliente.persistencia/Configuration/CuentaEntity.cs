using cliente.dominio.Entities.bp_cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cliente.persistencia.Configuration
{
    public class CuentaEntity : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {

            builder.HasKey(e => e.IdCuenta)
                    .HasName("PK__bp_cuent__C7E28685307D5F24");

            builder.ToTable("bp_cuenta");

            builder.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

            builder.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

            builder.Property(e => e.NumeroCuenta)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("numero_cuenta");

            builder.Property(e => e.SaldoInicial)
                    .HasColumnType("money")
                    .HasColumnName("saldo_inicial");

            builder.Property(e => e.TipoCuenta)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("tipo_cuenta")
                    .IsFixedLength();
        }
    }
}
