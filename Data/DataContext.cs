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
    public DbSet<MensajeUsuario> MensajeUsuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar la relación muchos a muchos entre Usuario y Mensaje
        modelBuilder.Entity<MensajeUsuario>()
            .HasKey(mu => new { mu.MensajeId, mu.UsuarioId });  // Compuesta por las dos claves foráneas

        modelBuilder.Entity<MensajeUsuario>()
            .HasOne(mu => mu.Mensaje)
            .WithMany(m => m.Receptores)
            .HasForeignKey(mu => mu.MensajeId);

        modelBuilder.Entity<MensajeUsuario>()
            .HasOne(mu => mu.Usuario)
            .WithMany(u => u.MensajesRecibidos)
            .HasForeignKey(mu => mu.UsuarioId);
    }
    public DbSet<EstadoAsistencia> EstadosAsistencias { get; set; }
    public DbSet<TipoActividad> TiposActividades { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }
    public DbSet<Actividad> Actividades { get; set; }

}
