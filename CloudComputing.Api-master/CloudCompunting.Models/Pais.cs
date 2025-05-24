using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Models
{
    public class Pais
    {
        public int Id { get; set; }         // PK
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public byte[]? FotografiaImg { get; set; } = new byte[0];
        // navigation properties
        public List<Autor>? Autores { get; set; }
        public List<Editorial>? Editoriales { get; set; }
    }
}
