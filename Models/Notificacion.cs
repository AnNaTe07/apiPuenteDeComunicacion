using Microsoft.EntityFrameworkCore;

namespace ApiPuenteDeComunicacion.Models
{
    public class Notificacion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}