namespace CinemaGo.Application.DTOs.Response;

public record CineResponse(
    int Id,
    string Nombre,
    string Direccion,
    double Latitud,
    double Longitud);