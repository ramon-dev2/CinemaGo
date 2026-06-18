using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaGo.Domain.Entities
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public ICollection<Sala> Salas { get; set; } = new List<Sala>();
    }
}
