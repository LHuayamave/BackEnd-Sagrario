using FacturasAPI.Entidad;
using FacturasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace FacturasAPI.DTOs
{
    public class FacturaCabeceraCreacionDTO
    {
        public DateTime Fecha { get; set; }
        public string NumeroFactura { get; set; }
        [Required]
        public DateTime FechaVencimiento { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string NombreCliente { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string NombreEmpresa { get; set; }
        [Required]
        public string DireccionEmpresa { get; set; }
        [Required]
        public string TelefonoEmpresa { get; set; }
        public List<FacturaDetalleCreacionDTO> FacturaDetalleCreacions { get; set; }
    }
}
