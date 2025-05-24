using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MedioPago { get; set; }
        public string EstadoPago { get; set; }

        public Inscripcion? Inscripcion { get; set; }
    }

}
