namespace ApiPuenteDeComunicacion.Models
{
    public class Horario
    {
        public int id { get; set; }
        public string dia { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
    }
}