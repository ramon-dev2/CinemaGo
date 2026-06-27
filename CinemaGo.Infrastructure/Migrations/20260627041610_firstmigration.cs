using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Direccion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: false),
                    Longitud = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cines", x => x.Id);
                    table.CheckConstraint("CK_Cine_Latitud", "\"Latitud\" >= -90 AND \"Latitud\" <= 90");
                    table.CheckConstraint("CK_Cine_Longitud", "\"Longitud\" >= -180 AND \"Longitud\" <= 180");
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Sinopsis = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    DuracionMinutos = table.Column<int>(type: "integer", nullable: false),
                    Clasificacion = table.Column<int>(type: "integer", nullable: false),
                    UrlPoster = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EstadoCartelera = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                    table.CheckConstraint("CK_Pelicula_DuracionMinutos", "\"DuracionMinutos\" > 0");
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Capacidad = table.Column<int>(type: "integer", nullable: false),
                    CineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                    table.CheckConstraint("CK_Sala_Capacidad", "\"Capacidad\" > 0");
                    table.ForeignKey(
                        name: "FK_Salas_Cines_CineId",
                        column: x => x.CineId,
                        principalTable: "Cines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaGeneros",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "integer", nullable: false),
                    PeliculasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaGeneros", x => new { x.GenerosId, x.PeliculasId });
                    table.ForeignKey(
                        name: "FK_PeliculaGeneros_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaGeneros_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Formato = table.Column<int>(type: "integer", nullable: false),
                    Idioma = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    SalaId = table.Column<int>(type: "integer", nullable: false),
                    PeliculaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.Id);
                    table.CheckConstraint("CK_Funcion_Precio", "\"Precio\" >= 0");
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cines_Nombre",
                table: "Cines",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId_FechaHora",
                table: "Funciones",
                columns: new[] { "PeliculaId", "FechaHora" });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId_FechaHora",
                table: "Funciones",
                columns: new[] { "SalaId", "FechaHora" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Nombre",
                table: "Generos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaGeneros_PeliculasId",
                table: "PeliculaGeneros",
                column: "PeliculasId");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_CineId_Nombre",
                table: "Salas",
                columns: new[] { "CineId", "Nombre" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "PeliculaGeneros");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Cines");
        }
    }
}
