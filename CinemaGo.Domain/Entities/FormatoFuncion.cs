namespace CinemaGo.Domain.Entities
{
    public enum FormatoFuncion
    {
        /// Proyección estándar 2D.
        DosD = 1,

        /// Proyección tridimensional con gafas.
        TresD = 2,

        /// Gran formato IMAX.
        IMAX = 3,

        /// Proyección 4DX con efectos sensoriales (movimiento, viento, agua, etc.).
        CuatroDX = 4,

        /// Proyección en pantalla gigante tipo Large Format.
        LargeFormat = 5,

        /// Proyección con experiencia sensorial premium (Dolby Atmos, butacas VIP, etc.).
        Premium = 6
    }
}
