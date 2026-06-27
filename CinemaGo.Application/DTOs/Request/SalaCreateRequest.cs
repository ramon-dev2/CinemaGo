using System.ComponentModel.DataAnnotations;

namespace CinemaGo.DTOs.Request;

public record SalaCreateRequest(
    [property: Required, MaxLength(80)] string Nombre,
    [property: Range(1, int.MaxValue)] int Capacidad,
    [property: Range(1, int.MaxValue)] int CineId);