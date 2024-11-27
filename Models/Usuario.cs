using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace ApiPuenteDeComunicacion.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; } = "";
        public string? Apellido { get; set; } = "";
        public int? Dni { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string? Salt { get; set; }

        [ForeignKey("rolId")]
        public int RolId { get; set; }

        public Rol? Rol { get; set; }
        public string? Avatar { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";

        // Relación muchos a muchos
        public List<MensajeUsuario> MensajesRecibidos { get; set; } = new List<MensajeUsuario>();
    }
}