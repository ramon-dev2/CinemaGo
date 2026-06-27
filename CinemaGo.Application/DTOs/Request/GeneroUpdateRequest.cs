using System.ComponentModel.DataAnnotations;

namespace CinemaGo.DTOs.Request;

public record GeneroUpdateRequest(
    [property: Required, MaxLength(60)] string Nombre);