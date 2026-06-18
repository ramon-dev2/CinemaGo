using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaGo.Domain.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Capacidad { get; set; }

        // Llave foránea que conecta la sala con su cine
        public int CineId { get; set; }
        public Cine Cine { get; set; } = null!;

        // Relación: En una sala se proyectan muchas funciones a lo largo del día
        public ICollection<Funcion> Funciones { get; set; } = new List<Funcion>();
    }
}
