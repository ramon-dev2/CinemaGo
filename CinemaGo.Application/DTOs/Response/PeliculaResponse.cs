using CinemaGo.Domain.Entities;

namespace CinemaGo.Application.DTOs.Response;

public record PeliculaResponse(
    int Id,
    string Titulo,
    string Sinopsis,
    int DuracionMinutos,
    Clasificacion Clasificacion,
    string UrlPoster,
    bool EstadoCartelera,
    IReadOnlyCollection<GeneroResponse> Generos);