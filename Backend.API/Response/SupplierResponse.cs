using Microsoft.VisualBasic;

namespace Backend.API.Response
{
    public class SupplierResponse
    {
        public int id { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public int identificacionTributaria { get; set; }
        public string numeroTelefonico { get; set; }
        public string email { get; set; }
        public string sitioWeb { get; set; }
        public string direccionFisica { get; set; }
        public string pais { get; set; }
        public int facturacionAnual { get; set; }
        public DateTime ultimaModificacion { get; set; }
    }
}
