using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosUTN.Models
{
    public class Certificado
    {
        [Key]
        public int InscripcionId { get; set; }
        public DateTime FechaEmision { get; set; }
        public string EstadoCertificado { get; set; }
        public string RutaArchivoPDF { get; set; }

        public Inscripcion? Inscripcion { get; set; }
    }


}
