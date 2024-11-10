using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiPuenteDeComunicacion.Migrations
{
    /// <inheritdoc />
    public partial class Modelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MensajeId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActividadId",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotificacionId",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadosAsistencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosAsistencias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Mensaje = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposActividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposActividades", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TipoActividadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NotificacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_Notificaciones_NotificacionId",
                        column: x => x.NotificacionId,
                        principalTable: "Notificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividades_TiposActividades_TipoActividadId",
                        column: x => x.TipoActividadId,
                        principalTable: "TiposActividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividades_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstadoAsistenciaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asistencias_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asistencias_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_EstadosAsistencias_EstadoAsistenciaId",
                        column: x => x.EstadoAsistenciaId,
                        principalTable: "EstadosAsistencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MensajeId",
                table: "Usuarios",
                column: "MensajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ActividadId",
                table: "Cursos",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_NotificacionId",
                table: "Cursos",
                column: "NotificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_NotificacionId",
                table: "Actividades",
                column: "NotificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_TipoActividadId",
                table: "Actividades",
                column: "TipoActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_UsuarioId",
                table: "Actividades",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ActividadId",
                table: "Asistencias",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_AlumnoId",
                table: "Asistencias",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_EstadoAsistenciaId",
                table: "Asistencias",
                column: "EstadoAsistenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_AlumnoId",
                table: "Calificaciones",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_MateriaId",
                table: "Calificaciones",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Actividades_ActividadId",
                table: "Cursos",
                column: "ActividadId",
                principalTable: "Actividades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Notificaciones_NotificacionId",
                table: "Cursos",
                column: "NotificacionId",
                principalTable: "Notificaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Mensajes_MensajeId",
                table: "Usuarios",
                column: "MensajeId",
                principalTable: "Mensajes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Actividades_ActividadId",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Notificaciones_NotificacionId",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Mensajes_MensajeId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "EstadosAsistencias");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "TiposActividades");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MensajeId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_ActividadId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_NotificacionId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "MensajeId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ActividadId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "NotificacionId",
                table: "Cursos");
        }
    }
}
