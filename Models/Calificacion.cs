using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPuenteDeComunicacion.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        [ForeignKey("MateriaId")]
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public decimal Nota { get; set; }
        public DateTime Fecha { get; set; }
        public Alumno Alumno { get; set; }

    }
}