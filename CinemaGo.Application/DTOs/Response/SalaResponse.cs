namespace CinemaGo.Application.DTOs.Response;

public record SalaResponse(
    int Id,
    string Nombre,
    int Capacidad,
    int CineId);