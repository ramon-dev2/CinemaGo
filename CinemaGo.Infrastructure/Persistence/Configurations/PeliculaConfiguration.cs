using CinemaGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaGo.Infrastructure.Persistence.Configurations;

public sealed class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
{
    public void Configure(EntityTypeBuilder<Pelicula> builder)
    {
        builder.Property(p => p.Titulo)
            .IsRequired()
            .HasMaxLength(160);

        builder.Property(p => p.Sinopsis)
            .HasMaxLength(2000);

        builder.Property(p => p.UrlPoster)
            .HasMaxLength(500);

        builder.HasMany(p => p.Generos)
            .WithMany(g => g.Peliculas)
            .UsingEntity(join => join.ToTable("PeliculaGeneros"));

        builder.ToTable(table =>
        {
            table.HasCheckConstraint("CK_Pelicula_DuracionMinutos", "\"DuracionMinutos\" > 0");
        });
    }
}

