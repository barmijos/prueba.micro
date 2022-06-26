using cliente.dominio.Entities.bp_cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cliente.persistencia.Configuration
{
    public class ClienteEntity : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            
            builder.HasKey(c => c.IdCliente)
                .HasName("PK__bp_clien__677F38F55941325F");
            
            builder.ToTable("bp_cliente");

            builder.Property(c => c.IdCliente).HasColumnName("id_cliente"); ;

            builder.Property(e => e.Contrasena)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("clave_cliente");

            builder.Property(e => e.Estado)
                   .HasMaxLength(1)
                   .IsUnicode(false)
                   .HasColumnName("estado")
                   .IsFixedLength();

            builder.Property(e => e.IdPersona)
                .HasColumnName("id_persona");

            builder.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bp_client__estad__74AE54BC");

        }
    }
}
