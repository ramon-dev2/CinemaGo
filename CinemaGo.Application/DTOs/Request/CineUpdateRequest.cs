using System.ComponentModel.DataAnnotations;

namespace CinemaGo.DTOs.Request;

public record CineUpdateRequest(
    [property: Required, MaxLength(150)] string Nombre,
    [property: Required, MaxLength(250)] string Direccion,
    [property: Range(-90, 90)] double Latitud,
    [property: Range(-180, 180)] double Longitud);