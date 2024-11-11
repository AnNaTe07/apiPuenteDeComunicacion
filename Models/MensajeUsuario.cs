using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiPuenteDeComunicacion.Models;

public class MensajeUsuario
{
    [ForeignKey("MensajeId")]
    public int MensajeId { get; set; }
    public Mensaje Mensaje { get; set; }
    [ForeignKey("UsuarioId")]
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}
