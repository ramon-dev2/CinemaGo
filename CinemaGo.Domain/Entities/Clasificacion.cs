namespace CinemaGo.Domain.Entities
{
    public enum Clasificacion
    {
        /// General Audiences - Apto para todas las edades.
        G = 1,

        /// Parental Guidance Suggested - Algunos materiales pueden no ser adecuados para niños.
        PG = 2,

        /// Parents Strongly Cautioned - Algunos materiales pueden ser inapropiados para menores de 13 años.
        PG_13 = 3,

        /// Restricted - Menores de 17 años requieren acompañamiento de un adulto.
        R = 4,

        /// No One 17 & Under Admitted - Solo adultos, mayores de 18 años.
        NC_17 = 5
    }
}
