using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventosUTN.Models;

namespace EventosUTN.Models
{
    public class Ponente
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Biografia { get; set; }

        public ICollection<EventoPonente>? EventoPonentes { get; set; }
    }

}
