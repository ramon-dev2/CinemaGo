using CinemaGo.Domain.Entities;

namespace CinemaGo.Application.DTOs.Response;

public record FuncionResponse(
    int Id,
    DateTime FechaHora,
    FormatoFuncion Formato,
    IdiomaFuncion Idioma,
    decimal Precio,
    int SalaId,
    int PeliculaId);