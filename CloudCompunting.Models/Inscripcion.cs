using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public int ParticipanteId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Estado { get; set; }

        public Evento? Evento { get; set; }
        public Participante? Participante { get; set; }
        public ICollection<Pago>? Pagos { get; set; }
        public Certificado? Certificado { get; set; }
    }

}
