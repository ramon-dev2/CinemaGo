using CinemaGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaGo.Infrastructure.Persistence.Configurations;

public sealed class SalaConfiguration : IEntityTypeConfiguration<Sala>
{
    public void Configure(EntityTypeBuilder<Sala> builder)
    {
        builder.Property(s => s.Nombre)
            .IsRequired()
            .HasMaxLength(80);

        builder.HasIndex(s => new { s.CineId, s.Nombre })
            .IsUnique();

        builder.HasOne(s => s.Cine)
            .WithMany(c => c.Salas)
            .HasForeignKey(s => s.CineId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint("CK_Sala_Capacidad", "\"Capacidad\" > 0");
        });
    }
}

