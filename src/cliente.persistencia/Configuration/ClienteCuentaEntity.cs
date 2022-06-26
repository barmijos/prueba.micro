using cliente.dominio.Entities.bp_cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cliente.persistencia.Configuration
{
    public class ClienteCuentaEntity : IEntityTypeConfiguration<ClienteCuenta>
    {
        public void Configure(EntityTypeBuilder<ClienteCuenta> builder)
        {
            builder.HasKey(e => e.IdClienteCuenta)
                   .HasName("PK__bp_clien__18B83731C8EB2A34");

            builder.ToTable("bp_cliente_cuenta");

            builder.Property(e => e.IdClienteCuenta).HasColumnName("id_cliente_cuenta");

            builder.Property(e => e.ClaveCliente)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("clave_cliente");

            builder.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado")
                .IsFixedLength();

            builder.Property(e => e.IdCliente).HasColumnName("id_cliente");

            builder.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

            builder.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.ClientesCuenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bp_client__id_cl__797309D9");

            builder.HasOne(d => d.IdCuentaNavigation)
                .WithMany(p => p.ClientesCuenta)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bp_client__id_cu__7A672E12");
        }
    }
}
