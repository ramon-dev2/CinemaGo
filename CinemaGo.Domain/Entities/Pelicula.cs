using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaGo.Domain.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Sinopsis { get; set; } = string.Empty;

        public int DuracionMinutos { get; set; }

        public Clasificacion Clasificacion { get; set; }

        public string UrlPoster { get; set; } = string.Empty;

        public bool EstadoCartelera { get; set; } = true;

        // Relación con los géneros (Una película puede tener varios géneros)
        public List<Genero> Generos { get; set; } = new List<Genero>();
        public ICollection<Funcion> Funciones { get; set; } = new List<Funcion>();
    }
}
