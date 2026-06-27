namespace CinemaGo.Domain.Entities
{
    public enum IdiomaFuncion
    {
        /// Audio doblado al espanol.
        Espanol = 1,

        /// Compatibilidad con nombre anterior.
        [Obsolete("Usa Espanol")]
        Espaniol = Espanol,

        /// Audio original en ingles con subtitulos en espanol.
        Subtitulada = 2,

        /// Audio original en ingles sin subtitulos.
        Original = 3
    }
}
