using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ApiPuenteDeComunicacion.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; } = "";
        public string? Apellido { get; set; } = "";
        public int Dni { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string email { get; set; } = "";
        public string password { get; set; } = "";

        [ForeignKey("rolId")]
        public int rolId { get; set; }

        public Rol Rol { get; set; }

        public List<Alumno> Alumnos { get; set; } //sólo si el rol es tutor
        public string NombreCompleto => $"{Nombre} {Apellido}";

        //contructor
        public Usuario(int id, string nombre, string email, string password, int rolId)
        {
            Id = id;
            Nombre = nombre;
            this.email = email;
            this.password = password;
            this.rolId = rolId;

            //inicializo la lista de alumnos sólo si el rol es tutor
            if (Rol.Nombre == "Tutor")
            {
                Alumnos = new List<Alumno>();
            }
            else
            {
                Alumnos = null;
            }

        }

        // Método para agregar alumnos (solo si el rol es TUTOR)
        public void AgregarAlumno(Alumno alumno)
        {
            if (Rol.Nombre == "Tutor")
            {
                Alumnos.Add(alumno);
            }
            else
            {
                throw new InvalidOperationException("Este usuario no tiene permisos para agregar alumnos.");
            }
        }
    }
}