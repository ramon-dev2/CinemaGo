using CinemaGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaGo.Infrastructure.Persistence.Configurations;

public sealed class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.Property(g => g.Nombre)
            .IsRequired()
            .HasMaxLength(60);

        builder.HasIndex(g => g.Nombre)
            .IsUnique();
    }
}

