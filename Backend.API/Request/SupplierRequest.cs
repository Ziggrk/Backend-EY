using System.ComponentModel.DataAnnotations;

namespace Backend.API.Request
{
    public class SupplierRequest
    {
        [Required]
        public string razonSocial { get; set; }
        [Required]
        public string nombreComercial { get; set; }
        [Required]
        public int identificacionTributaria { get; set; }
        [Required]
        public string numeroTelefonico { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string sitioWeb { get; set; }
        [Required]
        public string direccionFisica { get; set; }
        [Required]
        public string pais { get; set; }
        [Required]
        public int facturacionAnual { get; set; }

    }
}
