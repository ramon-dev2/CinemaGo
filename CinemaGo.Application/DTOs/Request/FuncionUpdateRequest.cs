using System.ComponentModel.DataAnnotations;
using CinemaGo.Domain.Entities;

namespace CinemaGo.DTOs.Request;

public record FuncionUpdateRequest(
    DateTime FechaHora,
    FormatoFuncion Formato,
    IdiomaFuncion Idioma,
    [property: Range(typeof(decimal), "0", "79228162514264337593543950335")] decimal Precio,
    [property: Range(1, int.MaxValue)] int SalaId,
    [property: Range(1, int.MaxValue)] int PeliculaId);