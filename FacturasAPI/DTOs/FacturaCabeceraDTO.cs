using FacturasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace FacturasAPI.DTOs
{
    public class FacturaCabeceraDTO
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroFactura { get; set; }
        [Required]
        public DateTime FechaVencimiento { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string NombreCliente { get; set; }
        [Required]
        public string NombreEmpresa { get; set; }
        [Required]
        public string DireccionEmpresa { get; set; }
        [Required]
        public string TelefonoEmpresa { get; set; }
        public double Total { get; set; }
        public List<FacturaDetalleDTO> FacturaDetalle { get; set; }
    }
}
