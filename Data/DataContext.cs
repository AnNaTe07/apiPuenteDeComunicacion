using Microsoft.EntityFrameworkCore;
using ApiPuenteDeComunicacion.Models;

namespace ApiPuenteDeComunicacion.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Horario> Horarios { get; set; }
    public DbSet<Nivel> Niveles { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Asistencia> Asistencias { get; set; }
    public DbSet<Calificacion> Calificaciones { get; set; }
    public DbSet<Mensaje> Mensajes { get; set; }
    public DbSet<EstadoAsistencia> EstadosAsistencias { get; set; }
    public DbSet<TipoActividad> TiposActividades { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }
    public DbSet<Actividad> Actividades { get; set; }

}
