using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN.Models
{
    public class Sesion
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public int SalaId { get; set; }

        public Evento? Evento { get; set; }
        public Sala? Sala { get; set; }
    }

}
