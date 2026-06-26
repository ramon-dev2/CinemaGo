using CinemaGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaGo.Infrastructure.Persistence.Configurations;

public sealed class FuncionConfiguration : IEntityTypeConfiguration<Funcion>
{
    public void Configure(EntityTypeBuilder<Funcion> builder)
    {
        builder.Property(f => f.Precio)
            .HasPrecision(10, 2);

        builder.HasIndex(f => new { f.SalaId, f.FechaHora })
            .IsUnique();

        builder.HasIndex(f => new { f.PeliculaId, f.FechaHora });

        builder.HasOne(f => f.Sala)
            .WithMany(s => s.Funciones)
            .HasForeignKey(f => f.SalaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.Pelicula)
            .WithMany(p => p.Funciones)
            .HasForeignKey(f => f.PeliculaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint("CK_Funcion_Precio", "\"Precio\" >= 0");
        });
    }
}

