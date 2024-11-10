using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPuenteDeComunicacion.Models
{
    public class Asistencia
    {
        public int Id { get; set; }

        [ForeignKey("EstadoAsistenciaId")]
        public int EstadoAsistenciaId { get; set; }
        public EstadoAsistencia Estado { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("AlumnoId")]
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }

    }
}