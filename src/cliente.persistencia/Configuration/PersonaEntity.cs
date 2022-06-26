using cliente.dominio.Entities.bp_cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cliente.persistencia.Configuration
{
    public class PersonaEntity : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("bp_persona");
            builder.HasKey(c => c.IdPersona)
                .HasName("PK__bp_perso__228148B0F2DD0904");

            builder.Property(e => e.IdPersona).HasColumnName("id_persona");

            builder.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion_persona");

            builder.Property(e => e.Edad).HasColumnName("edad_persona");

            builder.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("genero_persona")
                .IsFixedLength();

            builder.Property(e => e.Identificacion)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("identificacion_persona");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_persona");

            builder.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono_persona");


        }
    }
}
