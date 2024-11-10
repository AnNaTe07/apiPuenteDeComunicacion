using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPuenteDeComunicacion.Models
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("TipoActividadId")]
        public int TipoActividadId { get; set; }
        public TipoActividad TipoActividad { get; set; }
        public List<Asistencia> Asistencias { get; set; }
        public List<Curso> Cursos { get; set; }

        //Creador
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("NotificacionId")]
        public int NotificacionId { get; set; }
        public Notificacion Notificacion { get; set; }
    }
}