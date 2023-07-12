using FacturasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace FacturasAPI.Entidad
{
    public partial class FacturaCabecera
    {
        [Key]
        public int IdFacturaCabecera { get; set; }
        [Required]
        public DateTime FechaFacturaCreacion { get; set; }
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
        public double? Subtotal { get; set; }
        public double? Iva { get; set; }
        public double? TotalFactura { get; set; }
        public string EstadoFacturaCabecera { get; set; }
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();
    }
}
