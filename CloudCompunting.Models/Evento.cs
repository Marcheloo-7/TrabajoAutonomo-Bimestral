using EventosUTN.Models;

namespace EventosUTN.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string TipoEvento { get; set; }
        public string Ubicacion { get; set; }

        public ICollection<Sesion>? Sesiones { get; set; }
        public ICollection<Inscripcion>? Inscripciones { get; set; }
        public ICollection<EventoPonente>? EventoPonentes { get; set; }
    }

}
