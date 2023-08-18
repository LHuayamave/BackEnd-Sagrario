using FacturasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FacturasAPI.Entidad
{
    public partial class FacturaCabecera
    {
        [Key]
        public int IdFacturaCabecera { get; set; }
        public DateTime? FechaFacturaCreacion { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime? FechaVencimiento { get; set; }
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
        public decimal? Subtotal { get; set; }
        public decimal? Iva { get; set; }
        public decimal? TotalFactura { get; set; }
        public string EstadoFacturaCabecera { get; set; }
        public int IdPersona { get; set; }
        [JsonIgnore]
        public virtual Persona Persona { get; set; }
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();
    }
}
