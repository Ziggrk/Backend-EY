using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public required string razonSocial { get; set; }
        public required string nombreComercial { get; set; }
        public required int identificacionTributaria { get; set; }
        public required string numeroTelefonico { get; set; }
        public required string email { get; set; }
        public required string sitioWeb { get; set; }
        public required string direccionFisica { get; set; }
        public required string pais { get; set; }
        public required int facturacionAnual { get; set; }
        public DateTime ultimaModificacion { get; set; }

    }
}
