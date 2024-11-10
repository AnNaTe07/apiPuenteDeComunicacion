using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiPuenteDeComunicacion.Models
{
    public class Mensaje
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        //Emisor
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        //receptores
        public List<Usuario> Receptores { get; set; }
    }
}