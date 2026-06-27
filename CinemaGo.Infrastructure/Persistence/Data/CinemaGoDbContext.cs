using CinemaGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaGo.Infrastructure.Persistence;

public class CinemaGoDbContext(DbContextOptions<CinemaGoDbContext> options) : DbContext(options)
{
    public DbSet<Cine> Cines => Set<Cine>();
    public DbSet<Sala> Salas => Set<Sala>();
    public DbSet<Funcion> Funciones => Set<Funcion>();
    public DbSet<Pelicula> Peliculas => Set<Pelicula>();
    public DbSet<Genero> Generos => Set<Genero>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaGoDbContext).Assembly);
    }
}

