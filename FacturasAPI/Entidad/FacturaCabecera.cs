using FacturasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturasAPI.Entidad
{
    public class FacturaCabecera
    {
        [Key]
        public int IdFactura { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaVencimiento { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string NombreCliente { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string NombreEmpresa { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string DireccionEmpresa { get; set; }
        [Required]
        public string TelefonoEmpresa { get; set; }
        public double Total { get; set; }

        public FacturaDetalle FacturaDetalle { get; set; }
    }
}
