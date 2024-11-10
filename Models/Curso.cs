using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPuenteDeComunicacion.Models
{
    public class Curso
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        public List<Horario> Horarios { get; set; }

        public List<Alumno> Alumnos { get; set; }

        [ForeignKey("Nivel")]
        public int NivelId { get; set; }

        public Nivel Nivel { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}