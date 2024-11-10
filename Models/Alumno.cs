using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPuenteDeComunicacion.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }

        [ForeignKey("CursoId")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}