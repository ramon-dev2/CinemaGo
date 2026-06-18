using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaGo.Domain.Entities
{
    public class Funcion
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public FormatoFuncion Formato { get; set; }
        public IdiomaFuncion Idioma { get; set; }
        public decimal Precio { get; set; }

        // Llave foránea hacia la Sala
        public int SalaId { get; set; }
        public Sala Sala { get; set; } = null!;

        // Llave foránea hacia la Película
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
    }
}
