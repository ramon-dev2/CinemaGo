using System.ComponentModel.DataAnnotations;

namespace CinemaGo.DTOs.Request;

public record GeneroCreateRequest(
    [property: Required, MaxLength(60)] string Nombre);