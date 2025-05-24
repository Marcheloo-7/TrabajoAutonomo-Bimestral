using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventosUTN.Models;

namespace EventosUTN.Models
{
    public class EventoPonente
    {
        public int EventoId { get; set; }
        public int PonenteId { get; set; }

        public Evento? Evento { get; set; }
        public Ponente? Ponente { get; set; }
    }
}
