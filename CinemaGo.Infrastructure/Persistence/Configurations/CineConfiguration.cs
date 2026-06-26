using CinemaGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaGo.Infrastructure.Persistence.Configurations;

public sealed class CineConfiguration : IEntityTypeConfiguration<Cine>
{
    public void Configure(EntityTypeBuilder<Cine> builder)
    {
        builder.Property(c => c.Nombre)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.Direccion)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasIndex(c => c.Nombre);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint("CK_Cine_Latitud", "\"Latitud\" >= -90 AND \"Latitud\" <= 90");
            table.HasCheckConstraint("CK_Cine_Longitud", "\"Longitud\" >= -180 AND \"Longitud\" <= 180");
        });
    }
}

