using FacturasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace FacturasAPI.Entidad
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        [Required]
        public double PrecioUnitario { get; set; }
        public string EstadoProducto { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();
    }
}
