using System.ComponentModel.DataAnnotations;
using CinemaGo.Domain.Entities;

namespace CinemaGo.DTOs.Request;

public record PeliculaCreateRequest(
    [property: Required, MaxLength(160)] string Titulo,
    [property: MaxLength(2000)] string Sinopsis,
    [property: Range(1, int.MaxValue)] int DuracionMinutos,
    Clasificacion Clasificacion,
    [property: MaxLength(500)] string UrlPoster,
    bool EstadoCartelera,
    IReadOnlyCollection<int> GeneroIds);